using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_Comments.Service.ViewModels.Products;

public class ProductBaseViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string ImagePath { get; set; } = String.Empty;
    public string AuthorName { get; set; } = String.Empty;
    public string Category { get; set; } = String.Empty;
}
