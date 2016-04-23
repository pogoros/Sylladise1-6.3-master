using System;
using UIKit;
using Foundation;
using Parse;

namespace Sylladise1
{
	public class TableSource : UITableViewSource {
		string[] TableItems;
		string CellIdentifier = "TableCell";

			public TableSource (string[] items)
		{
			TableItems = items;

		}
			public override nint RowsInSection (UITableView tableview, nint section)
		{
			return TableItems.Length;

		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
		UITableViewCell cell = tableView.DequeueReusableCell (CellIdentifier);
		string item = TableItems[indexPath.Row];

		//---- if there are no cells to reuse, create a new one

		if (cell == null)
		{

			cell = new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier); 
		
		}
		
		// the cell’s Text property is set here
		cell.TextLabel.Text = item;

		return cell;
	}
}
}
