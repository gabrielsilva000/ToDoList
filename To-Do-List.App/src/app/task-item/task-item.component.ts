import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TaskItem } from '../models/task.item.model';

@Component({
  selector: 'app-task-item',
  standalone: false,
  templateUrl: './task-item.component.html',
  styleUrl: './task-item.component.css'
})
export class TaskItemComponent implements OnInit{

  form!: FormGroup;
  @Output() closeModal = new EventEmitter<void>();
  @Output() onSubmit = new EventEmitter<TaskItem>();
  @Input() btnAction!: string;
  @Input() btnTitle!: string;
  @Input() taskItem: TaskItem | null = null;

  constructor() { }

  ngOnInit(): void {
    this.form = new FormGroup({
      id: new FormControl(this.taskItem ? this.taskItem.id : 0),
      title: new FormControl(this.taskItem ? this.taskItem.title : '', [Validators.required]),
      description: new FormControl(this.taskItem ? this.taskItem.description : '', [Validators.required]),
      isCompleted: new FormControl(this.taskItem ? this.taskItem.isCompleted : false),
      dateCreation: new FormControl(new Date()),
      changeDate: new FormControl(new Date()),
    });
  }

  hideModal() {
    this.closeModal.emit();
  }

  submit(){
    this.onSubmit.emit(this.form.value);
  }
}
