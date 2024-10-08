﻿using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class MyPagerContainer<TData, TElementUI> : MonoBehaviour
    where TData : IDataItem
    where TElementUI : MonoBehaviour
{
    [SerializeField] private   int             _countVisibleItems = 9;
    [SerializeField] private   Transform       _itemsContainer;
    [SerializeField] private   MyToggleGroup   _toggleLeftRight;
    [SerializeField] private   TextMeshProUGUI _txtNoElements;
    [SerializeField] protected TextMeshProUGUI _txtPage;

    private List<TData>               _items;
    private TElementUI                _elementUI;
    private Action<TData, TElementUI> _initAction;
    private Action<int, bool>         _onPageChanged = null; // id and is_mouse_click

    private int _curPage = -1;
    private int _maxPages = -1;

    public int CurPage => _curPage;
    public int MaxPage => _maxPages;
    public int CountVisibleItems => _countVisibleItems;


    private void Awake()
    {
        _toggleLeftRight.InitAllToggles(false);
        _toggleLeftRight.OnToggleActivated += OnToggleActivated;
    }

    public void Init(List<TData> items, TElementUI elementUI, Action<TData, TElementUI> initAction, Action<int, bool> onPageChanged = null, bool isMouseClick = false)
    {
        DeleteAllItems();

        _items      = items;
        _elementUI  = elementUI;
        _initAction = initAction;
        _onPageChanged = onPageChanged;

        _curPage = -1;
        _maxPages    = (int)MathF.Ceiling((float)items.Count / _countVisibleItems);

        UpdateTextPage(1, _maxPages);
        ChangePage(1, isMouseClick);

        bool enableToggles = items.Count > _countVisibleItems;
        _toggleLeftRight.gameObject.SetActive(enableToggles);
        _txtPage.gameObject.SetActive(enableToggles);
    }

    private void OnToggleActivated(int id, bool isMouseClick)
    {
        if (id == 0)
        {
            OnClickPrevPage(isMouseClick);
        }else
        {
            OnClickNextPage(isMouseClick);
        }
    }

    public void OnClickNextPage(bool isMouseClick)
    {
        ChangePage(_curPage + 1, isMouseClick);
    }

    public void OnClickPrevPage(bool isMouseClick)
    {
        ChangePage(_curPage - 1, isMouseClick);
    }

    public void ChangePage(int page, bool isMouseClick)
    {
        bool elementsNotExist = _items == null || _items.Count == 0;
        EnableTextNoElements(elementsNotExist);

        if (elementsNotExist)
        {
            return;
        }

        int prevPage = _curPage;
        _curPage = Mathf.Clamp(page, 1, _maxPages);

        if (prevPage == _curPage)
        {
            return;
        }

        _toggleLeftRight.InitAllToggles(false);
        _toggleLeftRight.GetToggle(0).SetInteractable(_curPage != 1);
        _toggleLeftRight.GetToggle(1).SetInteractable(_curPage != _maxPages);

        UpdateTextPage(_curPage, _maxPages);
        int             fromIdx      = (_curPage - 1) * _countVisibleItems;
        List<TData> itemsToSpawn = _items.Skip(fromIdx).Take(_countVisibleItems).ToList();
        SpawnItems(itemsToSpawn, _elementUI, _initAction);

        _onPageChanged?.Invoke(_curPage, isMouseClick);
    }

    private void SpawnItems(List<TData> items, TElementUI elementUI, Action<TData, TElementUI> initAction)
    {
        DeleteAllItems();

        foreach (TData item in items)
        {
            TElementUI spawnedElementUI = Instantiate(elementUI as MonoBehaviour, _itemsContainer) as TElementUI;
            initAction?.Invoke(item, spawnedElementUI);
        }
    }
    
    private void DeleteAllItems()
    {
        for (int i = _itemsContainer.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(_itemsContainer.GetChild(i).gameObject);
        }
    }

    protected virtual void UpdateTextPage(int cur, int max)
    {
        _txtPage.text = $"{cur} / {max}";
    }

    private void EnableTextNoElements(bool enable)
    {
        _txtNoElements.gameObject.SetActive(enable);
    }
}

public interface IDataItem {} // interface for data in pager

public interface IElementUI {} // // interface for ui prefab in pager