using System;
using System.Collections.Generic;
using System.Linq;
using DisablakExtensions;
using TMPro;
using UnityEngine;


public class PagerContainer<TData, TElementUI> : MyMonoBehaviour
    where TData : IDataItem
    where TElementUI : MonoBehaviour
{
    [SerializeField] private int countVisibleItems = 9;
    [Space]
    [SerializeField] private   Transform       itemsContainer;
    [SerializeField] private   MyToggleGroup   toggleLeftRight;
    [SerializeField] private   TextMeshProUGUI txtNoElements;
    [SerializeField] protected TextMeshProUGUI txtPage;


    private List<TData>               _items;
    private TElementUI                _elementUI;
    private Action<TData, TElementUI> _initAction;
    private Action<int, bool>         _onPageChanged = null; // id and is_mouse_click

    private int _curPage = -1;
    private int _maxPages = -1;

    public int CurPage => _curPage;
    public int MaxPage => _maxPages;
    public int CountVisibleItems => countVisibleItems;


    private void Awake()
    {
        toggleLeftRight.InitAllToggles(false);
        toggleLeftRight.OnToggleActivated += OnToggleActivated;
    }

    public void Init(List<TData> items, TElementUI elementUI, Action<TData, TElementUI> initAction, Action<int, bool> onPageChanged = null, bool isMouseClick = false)
    {
        DeleteAllItems();

        _items      = items;
        _elementUI  = elementUI;
        _initAction = initAction;
        _onPageChanged = onPageChanged;

        _curPage = -1;
        _maxPages    = (int)MathF.Ceiling((float)items.Count / countVisibleItems);

        UpdateTextPage(1, _maxPages);
        ChangePage(1, isMouseClick);

        bool enableToggles = items.Count > countVisibleItems;
        toggleLeftRight.gameObject.SetActive(enableToggles);
        txtPage.gameObject.SetActive(enableToggles);
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

        toggleLeftRight.InitAllToggles(false);
        toggleLeftRight.GetToggle(0).SetInteractable(_curPage != 1);
        toggleLeftRight.GetToggle(1).SetInteractable(_curPage != _maxPages);

        UpdateTextPage(_curPage, _maxPages);
        int             fromIdx      = (_curPage - 1) * countVisibleItems;
        List<TData> itemsToSpawn = _items.Skip(fromIdx).Take(countVisibleItems).ToList();
        SpawnItems(itemsToSpawn, _elementUI, _initAction);

        _onPageChanged?.Invoke(_curPage, isMouseClick);
    }

    private void SpawnItems(List<TData> items, TElementUI elementUI, Action<TData, TElementUI> initAction)
    {
        DeleteAllItems();

        foreach (TData item in items)
        {
            TElementUI spawnedElementUI = Instantiate(elementUI as MonoBehaviour, itemsContainer) as TElementUI;
            initAction?.Invoke(item, spawnedElementUI);
        }
    }
    
    private void DeleteAllItems()
    {
        for (int i = itemsContainer.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(itemsContainer.GetChild(i).gameObject);
        }
    }

    protected virtual void UpdateTextPage(int cur, int max)
    {
        Color lightColor = new Color(0.67f, 0.71f, 0.78f);
        txtPage.text = $"Сторінки: {cur.ToString().ChangeColor(lightColor)} із {max.ToString().ChangeColor(lightColor)}";
    }

    private void EnableTextNoElements(bool enable)
    {
        txtNoElements.gameObject.SetActive(enable);
    }
}

public interface IDataItem {} // interface for data in pager

public interface IElementUI {} // // interface for ui prefab in pager