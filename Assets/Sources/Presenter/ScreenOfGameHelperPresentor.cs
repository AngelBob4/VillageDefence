using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOfGameHelperPresentor : IPresenter
{
    private ScreenOfGameHelper _screenOfGameHelper;
    private ScreenOfGameHelperView _screenOfGameHelperView;

    public ScreenOfGameHelperPresentor(ScreenOfGameHelper screenOfGameHelper, ScreenOfGameHelperView screenOfGameHelperView)
    {
        _screenOfGameHelper = screenOfGameHelper;
        _screenOfGameHelperView = screenOfGameHelperView;
    }

    public void Enable()
    {
        _screenOfGameHelperView.OnOpenButtonClicked += Open;
        _screenOfGameHelperView.OnExitButtonClicked += Close;
    }

    public void Disable()
    {
        _screenOfGameHelperView.OnOpenButtonClicked -= Open;
        _screenOfGameHelperView.OnExitButtonClicked -= Close;
    }

    private void Open()
    {
        _screenOfGameHelper.Open();
    }

    private void Close()
    {
        _screenOfGameHelper.Close();
    }
}