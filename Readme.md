# How to use the LayoutUpgrade event to upgrade a layout from one version to another

Let's suppose that you have an application and [save/restore the layout there](https://docs.devexpress.com/WPF/7391/common-concepts/saving-and-restoring-layouts). If you change certain layout settings in a new version of this application (e.g., show a panel, add another column, rearrange groups), these changes may be overridden when you restore the layout.

You can use the `DXSerializer.LayoutUpgrade` event and the `DXSerializer.LayoutVersion` property to maintain such changes.

```xml
<dxdo:DockLayoutManager
    ...
    dx:DXSerializer.LayoutUpgrade="OnDockLayoutManagerLayoutUpgrade"
    dx:DXSerializer.LayoutVersion="2.0"
    ... />
```

```cs
void OnDockLayoutManagerLayoutUpgrade(object sender, LayoutUpgradeEventArgs e) {
    if (e.RestoredVersion == "1.0") {
        //...
    }
}
```
```vb
Private Sub OnDockLayoutManagerLayoutUpgrade(ByVal sender As Object, ByVal e As LayoutUpgradeEventArgs)
	If e.RestoredVersion = "1.0" Then
		documentGroup1.MDIStyle = MDIStyle.MDI
	End If
End Sub
```

We raise `LayoutUpgrade` if the restored layout version is different from the current `LayoutVersion` value. I.e., you can increase `LayoutVersion` in a new version of your application and do the required changes in the `LayoutUpgrade` event handler.
