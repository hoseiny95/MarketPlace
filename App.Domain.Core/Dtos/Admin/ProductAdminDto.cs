using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Dtos.Admin;

public class ProductAdminDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string price { get; set; }
    public string BoothName { get; set; }
    public List<string> ImagePath { get; set; }

}
