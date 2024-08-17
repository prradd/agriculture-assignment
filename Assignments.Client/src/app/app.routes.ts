import { Routes } from '@angular/router';
import {TodoListComponent} from "./todo-list/todo-list.component";
import {AddTodoComponent} from "./add-todo/add-todo.component";

export const routes: Routes = [
  { path: '', redirectTo: '/todos', pathMatch: 'full' },
  { path: 'todos', component: TodoListComponent },
  { path: 'add-todo', component: AddTodoComponent }
];
