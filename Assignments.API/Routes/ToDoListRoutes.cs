﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Assignments.API.Routes
{
    public static class ToDoListRoutes
    {
        public static void MapToDoListRoutes(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(
                name: "GetAllToDoItems",
                pattern: "api/todolist",
                defaults: new { controller = "ToDoList", action = "GetToDoItems" });

            endpoints.MapControllerRoute(
                name: "GetAllTaskTypes",
                pattern: "api/todolist/task-types",
                defaults: new { controller = "ToDoList", action = "GetTaskTypes" });

            endpoints.MapControllerRoute(
                name: "GetToDoItem",
                pattern: "api/todolist/{id:int}",
                defaults: new { controller = "ToDoList", action = "GetToDoItem" });

            endpoints.MapControllerRoute(
                name: "PostToDoItem",
                pattern: "api/todolist",
                defaults: new { controller = "ToDoList", action = "PostToDoItem" });

            endpoints.MapControllerRoute(
                name: "PutToDoItem",
                pattern: "api/todolist/{id:int}",
                defaults: new { controller = "ToDoList", action = "PutToDoItem" });

            endpoints.MapControllerRoute(
                name: "DeleteToDoItem",
                pattern: "api/todolist/{id:int}",
                defaults: new { controller = "ToDoList", action = "DeleteToDoItem" });

            endpoints.MapControllerRoute(
                name: "UpdateCompleteDate",
                pattern: "api/todolist/{id:int}/toggle-complete",
                defaults: new { controller = "ToDoList", action = "UpdateCompleteDate" });

            endpoints.MapControllerRoute(
                name: "UpdateIsArchived",
                pattern: "api/todolist/{id:int}/toggle-archived",
                defaults: new { controller = "ToDoList", action = "UpdateIsArchived" });
        }
    }
}
