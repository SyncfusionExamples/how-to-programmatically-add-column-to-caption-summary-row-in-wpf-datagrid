# How to programmatically add column to caption summary row in WPF DataGrid (SfDataGrid)?

This sample show cases how to programmatically add column to caption summary row in [WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid)?
# About the sample

[WPF DataGrid](https://www.syncfusion.com/wpf-ui-controls/datagrid) (SfDataGrid) allows you to add column to [CaptionSummaryRow](https://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.Grid.SfDataGrid~CaptionSummaryRow.html) programmatically by adding [GridSummaryColumn](https://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.Grid.GridSummaryColumn.html) to [CaptionSummaryRow.SummaryColumns](https://help.syncfusion.com/cr/cref_files/wpf/Syncfusion.SfGrid.WPF~Syncfusion.UI.Xaml.Grid.GridSummaryRow~SummaryColumns.html).

```c#
dataGrid.Loaded += DataGrid_Loaded;
addColumn.Click += addColumn_Click;

private void DataGrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
{
    this.dataGrid.CaptionSummaryRow = new GridSummaryRow()
    {
        ShowSummaryInRow = true,
        Title = "Total Sales: {SalesAmount} for NumberOfYears: {NumberOfYears}",
        SummaryColumns = new ObservableCollection<ISummaryColumn>()
        {
            new GridSummaryColumn()
            {
                Name = "SalesAmount",
                MappingName="Total",
                SummaryType= SummaryType.Int32Aggregate,
                Format="{Sum:c}"
            }  ,
                new GridSummaryColumn()
            {
                Name = "NumberOfYears",
                MappingName="Year",
                SummaryType= SummaryType.CountAggregate,
                Format="{Count:d}"
            }
        }
    };
}
private void addColumn_Click(object sender, RoutedEventArgs e)
{
    this.dataGrid.CaptionSummaryRow.SummaryColumns.Add(new GridSummaryColumn() { Name = "Q1Sales", MappingName = "QS1", SummaryType = SummaryType.Int32Aggregate, Format = "{Sum:d}" });
    this.dataGrid.CaptionSummaryRow.Title = "Total Sales: {SalesAmount} for NumberOfYears: {NumberOfYears} and Quaterly Sales is {Q1Sales}";
    this.dataGrid.View.CaptionSummaryRow = this.dataGrid.CaptionSummaryRow;
    this.dataGrid.RowGenerator.Items.ForEach(o =>
    {
        if (o.RowType == RowType.CaptionCoveredRow || o.RowType == RowType.CaptionRow)
            o.GetType().GetProperty("RowIndex").SetValue(o, -1);
    });
    this.dataGrid.GetVisualContainer().InvalidateMeasureInfo();
}
```

KB article - [How to programmatically add column to caption summary row in WPF DataGrid (SfDataGrid)?](https://www.syncfusion.com/kb/11914/how-to-programmatically-add-column-to-caption-summary-row-in-wpf-datagrid-sfdatagrid)

## Requirements to run the demo
 Visual Studio 2015 and above versions
