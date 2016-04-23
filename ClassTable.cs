using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using Parse;

namespace Sylladise1
{
	partial class ClassTable : UITableViewController
	{
		public ClassTable (IntPtr handle) : base (handle)
		{
		}

		UITableView table;

		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			table = new UITableView(View.Bounds); // defaults to Plain style
			table.AutoresizingMask = UIViewAutoresizing.All;

			List<TableItem> tableItems = new List<TableItem> ();

			//build a query to get a list of records from the FavoriteFoods class in Parse
			// and sort the results by the ItemName column 
			var query = from ClassItem in ParseObject.GetQuery("Class") 
				orderby ClassItem["Class_Name"] ascending  
				select ClassItem;
			// make an asynchronous call to Parse to get the contents of the query above  
			IEnumerable<ParseObject> allClassListResult = await query.FindAsync();

			if (allClassListResult != null) 
			{
				// loop through the results and set the object properties  
				foreach (var allClassItem in allClassListResult) 
				{
					var ClassItem = new Classes()
					{ 
						Class_Name = allClassItem.Get<string>("Class_Name"),
						Description = allClassItem.Get<string> ("Description"),  
						Section = allClassItem.Get<string> ("Section"),  
					} ; 

					// assign the retrieved properties to the TableItem’s properties  
					tableItems.Add  
					(
						new TableItem (ClassItem.Description) {

							SubHeading=ClassItem.Class_Name,
							Description=("Section "+ ClassItem.Section)
							
						}
					);
		}
	}

			table.Source = new ImageTableSource(tableItems);
				Add (table);
			}
		}
	}
