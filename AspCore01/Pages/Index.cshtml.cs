using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore01.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Maintest();
        }

        public static void Maintest()
        {
            Console.WriteLine(Foo(30));
        }
        public static int Foo(int i)
        {
            if (i <= 0)
                return 0;
            else if (i > 0 && i <= 2)
                return 1;
            else return Foo(i - 1) + Foo(i - 2);
        }
    }
}
