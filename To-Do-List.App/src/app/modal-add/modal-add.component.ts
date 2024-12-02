import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TaskItem } from '../models/task.item.model';
import { TaskService } from '../services/task.service';

@Component({
  selector: 'app-modal-add',
  standalone: false,
  templateUrl: './modal-add.component.html',
  styleUrl: './modal-add.component.css'
})
export class ModalAddComponent {

  @Input()  showModal: boolean = false;
  @Output() closeModal = new EventEmitter<void>();
  btnAction = "Cadastrar!"
  btnTitle = "Cadastrar Tarefa!";

  constructor(private taskService: TaskService) { }

  hideModal() {
    this.closeModal.emit();
  }

  addTask(taskItem: TaskItem) {
    this.taskService.AddTask(taskItem).subscribe((data) => {
      this.hideModal();
      window.location.reload();
    });
  }

}
