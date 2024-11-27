using DomainModel;
using System;
using System.Windows;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    public static class InitialData
    {
        public static byte[] ImageToByteArray(Image imageIn)
        {
            ImageConverter converter = new ImageConverter();
            byte[] xByte = (byte[])converter.ConvertTo(imageIn, typeof(byte[]));
            return xByte;
        }
        public static IList<PizzaSize> PizzaSizeList => new List<PizzaSize> { 
            new PizzaSize(){Id=1, Name="маленькая", Price=200, Weight=250},
            new PizzaSize(){Id=2, Name="средняя", Price=300, Weight=370},
            new PizzaSize(){Id=3, Name="большая", Price=400, Weight=510},
        };
        public static IList<PizzaIngredient> PizzaIngredientList =>
            new List<PizzaIngredient> {
                new PizzaIngredient() {pizzaId=23, ingredientId=3},
                new PizzaIngredient() {pizzaId=23, ingredientId=4},
                new PizzaIngredient() {pizzaId=23, ingredientId=5},

                new PizzaIngredient() {pizzaId=24, ingredientId=4},
                new PizzaIngredient() {pizzaId=24, ingredientId=5},
                new PizzaIngredient() {pizzaId=24, ingredientId=6},

                new PizzaIngredient() {pizzaId=25, ingredientId=3},
                new PizzaIngredient() {pizzaId=25, ingredientId=4},
                new PizzaIngredient() {pizzaId=25, ingredientId=7},
                new PizzaIngredient() {pizzaId=25, ingredientId=8},
                new PizzaIngredient() {pizzaId=25, ingredientId=9},
                new PizzaIngredient() {pizzaId=25, ingredientId=10},

                new PizzaIngredient() {pizzaId=26, ingredientId=4},
                new PizzaIngredient() {pizzaId=26, ingredientId=8},
                new PizzaIngredient() {pizzaId=26, ingredientId=16},
                new PizzaIngredient() {pizzaId=26, ingredientId=22},
                new PizzaIngredient() {pizzaId=26, ingredientId=23},

                new PizzaIngredient() {pizzaId=27, ingredientId=4},
                new PizzaIngredient() {pizzaId=27, ingredientId=10},
                new PizzaIngredient() {pizzaId=27, ingredientId=11},
                new PizzaIngredient() {pizzaId=27, ingredientId=12},

                new PizzaIngredient() {pizzaId=28, ingredientId=4},
                new PizzaIngredient() {pizzaId=28, ingredientId=5},
                new PizzaIngredient() {pizzaId=28, ingredientId=7},
                new PizzaIngredient() {pizzaId=28, ingredientId=13},

                new PizzaIngredient() {pizzaId=29, ingredientId=4},
                new PizzaIngredient() {pizzaId=29, ingredientId=8},
                new PizzaIngredient() {pizzaId=29, ingredientId=10},
                new PizzaIngredient() {pizzaId=29, ingredientId=11},

                new PizzaIngredient() {pizzaId=30, ingredientId=4},
                new PizzaIngredient() {pizzaId=30, ingredientId=11},
                new PizzaIngredient() {pizzaId=30, ingredientId=14},
                new PizzaIngredient() {pizzaId=30, ingredientId=15},
                new PizzaIngredient() {pizzaId=30, ingredientId=16},
                new PizzaIngredient() {pizzaId=30, ingredientId=17},
                new PizzaIngredient() {pizzaId=30, ingredientId=21},

                new PizzaIngredient() {pizzaId=31, ingredientId=4},
                new PizzaIngredient() {pizzaId=31, ingredientId=10},
                new PizzaIngredient() {pizzaId=31, ingredientId=11},
                new PizzaIngredient() {pizzaId=31, ingredientId=12},
                new PizzaIngredient() {pizzaId=31, ingredientId=16},
                new PizzaIngredient() {pizzaId=31, ingredientId=18},
                new PizzaIngredient() {pizzaId=31, ingredientId=19},
                new PizzaIngredient() {pizzaId=31, ingredientId=20}
            };
        public static IList<Pizza> PizzaList => new List<Pizza>
        {
            
            new Pizza() {Id = 24, Name="Сырная", Active=true,
                Description="Традиционная сырная пицца с моцареллой, сырами чеддер и пармезан и соусом альфредо",
            Pizzaimage=DAL.Properties.Resources.cheese},
            new Pizza() {Id = 25, Name="Мясная", Active=true,
                Description="Нежный цыпленок, ветчина, пепперони, острая чоризо, моцарелла, фирменный томатный соус... Настоящее наслаждение для целителей пиццы",
            Pizzaimage=DAL.Properties.Resources.meat},
            new Pizza() {Id = 26, Name="Мясное барбекю", Active=true,
                Description="Пепперони, альпийские колбаски, моцарелла и соус барбекю - отличный вариант для пиццы на свежем воздухе!",
            Pizzaimage=DAL.Properties.Resources.meatbbq},
            new Pizza() {Id = 27, Name="Маргарита", Active=true,
                Description="Известная пицца с моцареллой, томатами, итальянскими травами и фирменным томатным соусом",
            Pizzaimage=DAL.Properties.Resources.mozzarella},
            new Pizza() {Id = 28, Name="Гавайская", Active=true,
                Description="Нежный цыпленок, сочный ананасы, моцарелла и фирменный соус альфредо - все для любителей гавайской пиццы",
            Pizzaimage=DAL.Properties.Resources.hawaii},
            new Pizza() {Id = 29, Name="Пепперони", Active=true,
                Description="Пикантная пепперони, моцарелла, свежие томаты, фирменный томатный соус",
            Pizzaimage=DAL.Properties.Resources.pepperoni},
            new Pizza() {Id = 30, Name="Лососевая", Active=true,
                Description="Моцарелла, лосось, кверетки, томаты, красный лук, брокколи, базилик",
            Pizzaimage=DAL.Properties.Resources.salmon},
            new Pizza() {Id = 31, Name="Вегетарианская", Active=true,
                Description="Прекрасный выбор для вегетарианцев: шампиньоны, томаты, перец, красный лук, брынза, моцарелла, томатный соус, итальянские травы - и никакого мяса!",
            Pizzaimage=DAL.Properties.Resources.mushroom},
            new Pizza() {Id = 32, Name="Пользовательская", Active=true,
                Description="Не нашли пиццу, которую хотели? Тогда создайте свою!",
            Pizzaimage=DAL.Properties.Resources.custom},
        };
        public static IList<Ingredient> IngredientList => new List<Ingredient> { 
            new Ingredient(){Id = 3, Name = "ветчина", Small = 20, Medium = 25, Big = 30, 
                Active = true, PricePerGram = 2,
            Ingrimage = Properties.Resources.hamIngr},
            new Ingredient(){Id = 4, Name = "моцарелла", Small = 25, Medium = 35, Big = 45,
                Active = true, PricePerGram = 2,
            Ingrimage = Properties.Resources.mozzarellaIngr},
            new Ingredient(){Id = 5, Name = "соус альфредо", Small = 25, Medium = 25, 
                Big = 45,
                Active = true, PricePerGram = 2,
            Ingrimage = Properties.Resources.alfredosauceIngr},
            new Ingredient(){Id = 6, Name = "сыры чеддер и пармезан", Small = 20, 
                Medium = 30,
                Big = 40,
                Active = true, PricePerGram = 3,
            Ingrimage = Properties.Resources.cheddarandparmesanIngr},
            new Ingredient(){Id = 7, Name = "цыпленок", Small = 30, Medium = 40, Big = 50,
                Active = true, PricePerGram = 3,
            Ingrimage = Properties.Resources.chickIngr},
            new Ingredient(){Id = 8, Name = "пепперони", Small = 25, Medium = 35, Big = 45,
                Active = true, PricePerGram = 2,
            Ingrimage = Properties.Resources.pepperoniIngr},
            new Ingredient(){Id = 9, Name = "колбаски чоризо", Small = 15, Medium = 20, 
                Big = 25,
                Active = true, PricePerGram = 2.5M,
            Ingrimage = Properties.Resources.chorizoIngr},
            new Ingredient(){Id = 10, Name = "томатный соус", Small = 25, Medium = 35, 
                Big = 45,
                Active = true, PricePerGram = 1.5M,
            Ingrimage = Properties.Resources.tomatosauceIngr},
            new Ingredient(){Id = 11, Name = "томаты", Small = 20, Medium = 25, Big = 30,
                Active = true, PricePerGram = 2,
            Ingrimage = Properties.Resources.tomatoIngr},
            new Ingredient(){Id = 12, Name = "итальянские травы", Small = 5, Medium = 7.5M, 
                Big = 10,
                Active = true, PricePerGram = 2,
            Ingrimage = Properties.Resources.ItalianherbsIngr},
            new Ingredient(){Id = 13, Name = "ананасы", Small = 15, Medium = 20, Big = 25,
                Active = true, PricePerGram = 3,
            Ingrimage = Properties.Resources.PineapplesIngr},
            new Ingredient(){Id = 14, Name = "лосось", Small = 30, Medium = 40, Big = 50,
                Active = true, PricePerGram = 3,
            Ingrimage = Properties.Resources.salmonIngr},
            new Ingredient(){Id = 15, Name = "креветки", Small = 20, Medium = 25, Big = 30,
                Active = true, PricePerGram = 5,
            Ingrimage = Properties.Resources.ShrimpsIngr},
            new Ingredient(){Id = 16, Name = "красный лук", Small = 10, Medium = 20, 
                Big = 30,
                Active = true, PricePerGram = 2,
            Ingrimage = Properties.Resources.OnionIngr},
            new Ingredient(){Id = 17, Name = "брокколи", Small = 10, Medium = 15, Big = 20,
                Active = true, PricePerGram = 3,
            Ingrimage = Properties.Resources.broccoliIngr},
            new Ingredient(){Id = 18, Name = "шампиньоны", Small = 15, Medium = 25, Big = 35,
                Active = true, PricePerGram = 3,
            Ingrimage = Properties.Resources.ShrimpsIngr},
            new Ingredient(){Id = 19, Name = "сладкий перец", Small = 15, Medium = 20, 
                Big = 25,
                Active = true, PricePerGram = 2,
            Ingrimage = Properties.Resources.PepperIngr},
            new Ingredient(){Id = 20, Name = "брынза", Small = 15, Medium = 25, Big = 35,
                Active = true, PricePerGram = 4,
            Ingrimage = Properties.Resources.fetacheeseIngr},
            new Ingredient(){Id = 21, Name = "базилик", Small = 5, Medium = 7.5M, Big = 10,
                Active = true, PricePerGram = 1.5M,
            Ingrimage = Properties.Resources.basilIngr},
            new Ingredient(){Id = 22, Name = "альпийские колбаски", Small = 15, Medium = 25,
                Big = 35,
                Active = true, PricePerGram = 4,
            Ingrimage = Properties.Resources.AlpinesausagesIngr},
            new Ingredient(){Id = 23, Name = "соус барбекю", Small = 30, Medium = 35, 
                Big = 40,
                Active = true, PricePerGram = 2,
            Ingrimage = Properties.Resources.bbqsauceIngr},
            new Ingredient(){Id = 24, Name = "сырный бортик", Small = 40, Medium = 60, 
                Big = 80,
                Active = true, PricePerGram = 2,
            Ingrimage = Properties.Resources.CheeseSideIngr}
        };
        public static IList<Client> ClientList => new List<Client> { 
            new Client(){Address="г. Иваново, пл. Победы, д. 65",Id=3, FirstName="Никита", LastName="Крылов", Surname="Романович",
            Login="myname2", Password="mypassword", Phone="89003376723", Email="email100@dfr.ru"
            }
        };
        public static IList<Courier> CourierList => new List<Courier> {
            new Courier(){Id=10, FirstName="Николай", LastName="Морев", Surname="Валерьевич",
            Login="mylogin1", Password="mypassword", Phone="89003318989", Email="email3@dfr.ru"}
        };
        public static IList<Manager> ManagerList => new List<Manager> {
        new Manager(){Id=2, FirstName="Игорь", LastName="Хайрдинов", Surname="Юрьевич",
            Login="myname", Password="mypassword",Phone="89003334545", Email="email@dfr.ru"}
        };
        public static IList<DelStatus> DelStatusList => new List<DelStatus> {
            new DelStatus(){Id=1,Description="Не оформлен"},
            new DelStatus(){Id=2,Description="Отменен"},
            new DelStatus(){Id=3,Description="Формируется"},
            new DelStatus(){Id=5,Description="Передан курьеру"},
            new DelStatus(){Id=6,Description="Доставлен"},
            new DelStatus(){Id=7,Description="Не доставлен"},
            new DelStatus(){Id=8,Description="Передается в доставку"}

        };
        public static IList<Order> OrderList => new List<Order> { 
            new Order(){Id=2, ClientId=3, CourierId=10, FinalPrice=360, 
                AddressDel="Ул. Космонавтов, д.127", Weight=320, 
                Ordertime=DateTime.ParseExact("2024-09-18 17:46:23", "yyyy-MM-dd HH:mm:ss", null),
            DelstatusId=5, ManagersId=2},
            new Order(){Id=7, ClientId=3, CourierId=10, FinalPrice=1625,
                AddressDel="Мельничный пер., д.10", Weight=1370,
                Ordertime=DateTime.ParseExact("2024-09-10 12:10:00","yyyy-MM-dd HH:mm:ss", null),
            DelstatusId=6, ManagersId=2,
            Deliverytime = DateTime.ParseExact("2024-09-10 12:30:16","yyyy-MM-dd HH:mm:ss", null)},
            new Order(){Id=8, ClientId=3, CourierId=10, FinalPrice=505,
                AddressDel="Ул. Тимирязева, д.16", Weight=390,
                Ordertime=DateTime.ParseExact("2024-09-09 15:12:12","yyyy-MM-dd HH:mm:ss", null),
            DelstatusId=6, ManagersId=2,
            Deliverytime=DateTime.ParseExact("2024-09-10 15:12:12","yyyy-MM-dd HH:mm:ss", null)
            }
        };
        public static IList<OrderLine> OrderLineList => new List<OrderLine> {
            new OrderLine(){Id=2, Custom=false, OrdersId=2, PizzaId=24,
            Quantity=1, PositionPrice=360, PizzaSizesId=1, Weight=320},
            new OrderLine(){Id=8, Custom=true, OrdersId=7, PizzaId=24,
            Quantity=1, PositionPrice=400, PizzaSizesId=1, Weight=340},
            new OrderLine(){Id=9, Custom=false, OrdersId=7, PizzaId=24,
            Quantity=2, PositionPrice=720, PizzaSizesId=1, Weight=640},
            new OrderLine(){Id=10, Custom=false, OrdersId=7, PizzaId=25,
            Quantity=1, PositionPrice=505, PizzaSizesId=1, Weight=390},
            new OrderLine(){Id=11, Custom=false, OrdersId=8, PizzaId=25,
            Quantity=1, PositionPrice=505, PizzaSizesId=1, Weight=390}
        };
        public static IList<CustomIngredient> CustomIngredientList => 
            new List<CustomIngredient> { 
                new CustomIngredient(){orderLineId=8, ingredientId=3}
            };
        public static IList<User> UserList => new List<User> {
            new User(){Id=2, FirstName="Игорь", LastName="Хайрдинов", Surname="Юрьевич",
            Login="myname", Password="mypassword",Phone="89003334545", Email="email@dfr.ru"
            },
            new User(){Id=3, FirstName="Никита", LastName="Крылов", Surname="Романович",
            Login="myname2", Password="mypassword", Phone="89003376723", Email="email100@dfr.ru"},
            new User(){Id=10, FirstName="Николай", LastName="Морев", Surname="Валерьевич",
            Login="mylogin1", Password="mypassword", Phone="89003318989", Email="email3@dfr.ru"}
        
        };
    }
}
