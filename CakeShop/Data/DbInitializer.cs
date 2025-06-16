using CakeShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CakeShop.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // 檢查資料庫是否存在，如果不存在則建立
            context.Database.EnsureCreated();

            // 檢查是否已有蛋糕資料
            if (context.Cakes.Any())
            {
                context.Cakes.RemoveRange(context.Cakes);
                context.SaveChanges();   
            }

            var cakes = new Cake[]
            {
                new Cake{Name="經典巧克力蛋糕", Description="濃郁滑順的黑巧克力甘納許", Price=550.00m, ImageUrl="/images/chocolate_cake.jpg"},
                new Cake{Name="草莓鮮奶油蛋糕", Description="新鮮草莓搭配輕盈鮮奶油", Price=620.00m, ImageUrl="/images/strawberry_cream_cake.jpg"},
                new Cake{Name="檸檬起司蛋糕", Description="清爽檸檬風味的重乳酪蛋糕", Price=580.00m, ImageUrl="/images/lemon_cheesecake.jpg"},
                new Cake{Name="抹茶紅豆慕斯", Description="日式抹茶與蜜紅豆的完美結合", Price=650.00m, ImageUrl="/images/matcha_redbean_mousse.jpg"},
                new Cake{Name="提拉米蘇", Description="義大利經典咖啡酒香甜點", Price=500.00m, ImageUrl="/images/tiramisu.jpg"}
            };

            foreach (Cake c in cakes)
            {
                context.Cakes.Add(c);
            }
            context.SaveChanges(); // 儲存蛋糕資料

            // 可以在這裡加入其他的初始資料，例如管理員帳號等
        }
    }
}