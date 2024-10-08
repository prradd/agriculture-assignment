import { Component, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { TodoItem } from '../todoitem';
import { HttpClient } from '@angular/common/http';
import { Button } from 'primeng/button';
import { CommonModule, DatePipe } from '@angular/common';
import { Router } from '@angular/router';
import { ButtonGroupModule } from 'primeng/buttongroup';
import { CheckboxModule } from 'primeng/checkbox';
import { FormsModule } from '@angular/forms';
import { environment } from '../../enviroments/enviroment';

const { apiUrl } = environment;

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
  styleUrls: ['./todo-list.component.css'],
})
export class TodoListComponent implements OnInit {
  todos: TodoItem[] = [];
  constructor(
    private http: HttpClient,
    private router: Router,
  ) {}

  ngOnInit() {
    this.fetchTodos();
  }

  fetchTodos() {
    this.http
      .get<TodoItem[]>(`${apiUrl}/todolist`)
      .subscribe((todos) => (this.todos = todos));
  }

  goToAddTodo() {
    this.router.navigate(['/add-todo']).then((r) => console.log(r));
  }

  updateTask(todo: TodoItem) {
    this.http
      .put(`${apiUrl}/todolist/${todo.id}/toggle-complete`, !!todo.completeDate)
      .subscribe(() => this.fetchTodos());
  }

  deleteTask(id: number) {
    this.http
      .delete(`${apiUrl}/todolist/${id}`)
      .subscribe(() => this.fetchTodos());
  }

  archiveTask(todo: TodoItem) {
    this.http
      .put(`${apiUrl}/todolist/${todo.id}/toggle-archived`, !todo.isArchived)
      .subscribe(() => this.fetchTodos());
  }
}
