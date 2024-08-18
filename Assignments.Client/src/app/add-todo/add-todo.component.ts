import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { DropdownModule } from 'primeng/dropdown';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { InputTextModule } from 'primeng/inputtext';
import { CommonModule } from '@angular/common';
import { TaskType } from '../todoitem';
import { HttpClient } from '@angular/common/http';
import { CheckboxModule } from 'primeng/checkbox';
import { environment } from '../../enviroments/enviroment';

const { apiUrl } = environment;
@Component({
  selector: 'app-add-todo',
  standalone: true,
  imports: [
    InputTextModule,
    InputTextareaModule,
    CalendarModule,
    ButtonModule,
    DropdownModule,
    ReactiveFormsModule,
    CommonModule,
    CheckboxModule,
  ],
  templateUrl: './add-todo.component.html',
  styleUrl: './add-todo.component.css',
})
export class AddTodoComponent implements OnInit {
  public todoForm: FormGroup;
  taskTypes: TaskType[] = [];

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router,
  ) {
    this.todoForm = this.fb.group({
      taskType: ['', Validators.required],
      name: ['', [Validators.required, Validators.minLength(3)]],
      description: [''],
      startDate: ['', Validators.required],
      dueDate: ['', Validators.required],
      isRepeating: [false],
    });
  }

  ngOnInit(): void {
    this.fetchTaskTypes();
  }

  fetchTaskTypes(): void {
    this.http
      .get<TaskType[]>(`${apiUrl}/todolist/task-types`)
      .subscribe((data) => {
        this.taskTypes = data;
      });
  }

  onSubmit(): void {
    const payload = {
      taskTypeId: this.todoForm.value.taskType,
      ...this.todoForm.value,
    };

    delete payload.taskType;

    this.http
      .post(`${apiUrl}/todolist`, payload)
      .subscribe((res) => console.log('Response:', res));

    this.router.navigate(['/todos']);
  }

  onCancel(): void {
    this.router.navigate(['/todos']);
  }
}
