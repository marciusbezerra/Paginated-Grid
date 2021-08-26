using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestGridPaginated.Models;

namespace TestGridPaginated.Services {
    public class DataService {
        public static void Initialize (IServiceProvider serviceProvider) {
            using (var context = new TodoContext (serviceProvider.GetRequiredService<DbContextOptions<TodoContext>> ())) {
                if (context.Todos.Any ()) return;

                for (int i = 0; i < 100; i++) {
                    context.Todos.Add (new Todo {
                        Title = $"Title {i}",
                            Description = $"Description {i}",
                            CreatedAt = DateTime.Now,
                            Done = false
                    });
                }

                context.SaveChanges ();
            }

        }
    }
}