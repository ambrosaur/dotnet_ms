using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        // This variable will hold a reference to a PizzaService object
        private readonly PizzaService _service;

        /** 
            hold the list of pizzas 
            default! - initialized later, so null safety checks aren't required
        */
        public IList<Pizza> PizzaList { get; set;} = default!;

        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }
    }
}
