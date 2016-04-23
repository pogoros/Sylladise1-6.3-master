using System;
using UIKit;
using Foundation;
using Parse;
using System.Collections.Generic;  
using System.Linq;
using System.IO;


namespace Sylladise1
{

		public class ImageTableSource : UITableViewSource  
		{
			protected string cellIdentifier = "TableCell";

			Dictionary<string, List<TableItem>> indexedTableItems;
			string[] keys; 

			public ImageTableSource (List<TableItem> items) 
		{
			indexedTableItems = new Dictionary<string, List<TableItem>> ();
			foreach (var t in items) {
					
				if (indexedTableItems.ContainsKey (t.SubHeading)) 
				{
					indexedTableItems [t.SubHeading].Add (t); 
				} 
				else 
				{ 
					indexedTableItems.Add (t.SubHeading, new List<TableItem> () { t });
				}
			}
			keys = indexedTableItems.Keys.ToArray ();
		}
				public override nint NumberOfSections (UITableView tableView)
				{
					return keys.Length; 
				}

				/// <summary> 
				/// Determines how many cells to create for that particular section.  /// </summary> 
				public override nint RowsInSection (UITableView tableview, nint section) 
				{
					return indexedTableItems[keys[section]].Count; 
				}

				public override string TitleForHeader (UITableView tableView, nint section)

				{
					return keys[section]; 
				}

				public override string TitleForFooter (UITableView tableView, nint section)
				{
			return null;
				}

				public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
				{
					new UIAlertView("Row Selected" 
						, indexedTableItems[keys[indexPath.Section]][indexPath.Row].Heading  , null, "OK", null).Show(); 
					tableView.DeselectRow (indexPath, true); 
				}

				/// <summary> 
				/// Gets the actual UITableViewCell to render for the particular section and row 
				/// </summary>
				//---- declare vars
				public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)  
						{
						UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);  
						TableItem item = indexedTableItems[keys[indexPath.Section]][indexPath.Row];  

					//---- if there are no cells to reuse, create a new one  
					if (cell == null)
					{
						cell = new UITableViewCell (UITableViewCellStyle.Subtitle, cellIdentifier);  
					}

						cell.TextLabel.Text = item.Heading; 
						cell.DetailTextLabel.Text = item.Description; 
						//cell.ImageView.Image = UIImage.FromFile("Images/" + item.ImageName);

					return cell; 

		
	}
}
}
