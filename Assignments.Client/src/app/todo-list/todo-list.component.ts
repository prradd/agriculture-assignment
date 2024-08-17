import {Component} from '@angular/core';
import {TableModule} from "primeng/table";
import {TodoItem} from "../todoitem";
import {HttpClient} from "@angular/common/http";
import {Button} from "primeng/button";
import {CommonModule, DatePipe} from "@angular/common";
import {Router} from "@angular/router";
import {ButtonGroupModule} from "primeng/buttongroup";
import {CheckboxModule} from "primeng/checkbox";
import {FormsModule} from "@angular/forms";

@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [
    CommonModule,
    TableModule,
    Button,
    DatePipe,
    ButtonGroupModule,
    CheckboxModule,
    FormsModule,
  ],
  templateUrl: './todo-list.component.html',
  styleUrl: './todo-list.component.css',
})
export class TodoListComponent {
  todos: TodoItem[] = [];
  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit() {
    this.fetchTodos();
  }

  fetchTodos() {
    this.http.get<TodoItem[]>('https://localhost:44323/api/todolist')
      .subscribe(todos => this.todos = todos);
  }

  completeTask(todo: TodoItem) {
    this.http.put(`https://localhost:44323/api/todolist/${todo.id}`, todo)
      .subscribe(() => this.fetchTodos());
  }

  goToAddTodo() {
    this.router.navigate(['/add-todo']).then(r => console.log(r));
  }

  updateTask(todo: TodoItem) {
    this.http.put(`https://localhost:44323/api/todolist/${todo.id}/toggle-complete`, !!todo.completeDate)
      .subscribe(() => this.fetchTodos());
  }

  deleteTask(id: number) {
    this.http.delete(`https://localhost:44323/api/todolist/${id}`)
      .subscribe(() => this.fetchTodos());
  }

  archiveTask(todo: TodoItem) {
    this.http.put(`https://localhost:44323/api/todolist/${todo.id}/toggle-archived`, !todo.isArchived)
      .subscribe(() => this.fetchTodos());
  }
}
