<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128642518/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T163763)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WPF Dock Layout Manager - Use the Layout Upgrade Event to Upgrade a Layout from One Version to Another

You may have an application and [save/restore](https://docs.devexpress.com/WPF/7391/common-concepts/saving-and-restoring-layouts) its layout. If you change layout settings(show a panel, add another column, rearrange groups, and other), you can override these changes when you restore the layout.

Use the `DXSerializer.LayoutUpgrade` event and the `DXSerializer.LayoutVersion` property to maintain changes.

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
        '...
    End If
End Sub
```

The `LayoutUpgrade` event is raised if the restored layout version is different from the current `LayoutVersion` value. You can increase `LayoutVersion` in a new version of your application and do the required changes in the `LayoutUpgrade` event handler.

<!-- default file list -->
## Files to Look At

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
<!-- default file list end -->

## Documentation

- [Save/Restore Control Layout](https://docs.devexpress.com/WPF/7391/common-concepts/saving-and-restoring-layouts)
