using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace SfDataGridDemo
{
    public class SfDataGridBehavior : Behavior<Grid>
    {
        SfDataGrid dataGrid;
        Button addColumn;
        protected override void OnAttached()
        {
            base.OnAttached();
            dataGrid = this.AssociatedObject.FindName("sfdatagrid") as SfDataGrid;
            addColumn = this.AssociatedObject.FindName("addColumn") as Button;
            dataGrid.Loaded += DataGrid_Loaded;
            addColumn.Click += addColumn_Click;
        }

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
    }
}
