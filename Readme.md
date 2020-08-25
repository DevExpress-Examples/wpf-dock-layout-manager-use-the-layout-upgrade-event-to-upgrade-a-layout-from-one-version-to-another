<!-- default file list -->
*Files to look at*:

* **[MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))**
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
<!-- default file list end -->
# How to use the LayoutUpgrade event to upgrade a layout from one version to another


<p>Sometimes it may be necessary to change the layout in your application (e.g., add a panel into the `DockLayoutManager`, rearrange groups, or add columns into the `GridControl`). In this case, a previously saved layout may require manual patching during the layout restoration. For this purpose, you can use the `DXSerializer.LayoutUpgrade` event. This event is raised if a restored layout version is lower than the current one. To set a layout version, use the `DXSerializer.LayoutVersion` attached property. </p>

<br/>


