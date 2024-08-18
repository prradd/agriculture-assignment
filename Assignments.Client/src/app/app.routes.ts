import { Routes } from '@angular/router';
import { TodoListComponent } from './todo-list/todo-list.component';

export const routes: Routes = [
  { path: '', redirectTo: '/todos', pathMatch: 'full' },
  { path: 'todos', component: TodoListComponent },
  {
    path: 'add-todo',
    loadComponent: () =>
      import('./add-todo/add-todo.component').then((m) => m.AddTodoComponent),
  },
];
