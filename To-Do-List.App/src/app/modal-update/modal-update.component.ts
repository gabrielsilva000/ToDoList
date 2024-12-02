import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { TaskService } from '../services/task.service';
import { TaskItem } from '../models/task.item.model';

@Component({
  selector: 'app-modal-update',
  standalone: false,
  templateUrl: './modal-update.component.html',
  styleUrl: './modal-update.component.css'
})
export class ModalUpdateComponent implements OnChanges {

  @Input() showModal: boolean = false;
  @Input() updateTaskId?: number;
  @Output() closeModal = new EventEmitter<void>();
  btnAction = "Editar!"
  btnTitle = "Editar Tarefa!";
  taskItem!: TaskItem;
  ngChangesId: boolean = false;

  constructor(private taskService: TaskService) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['updateTaskId'] && this.updateTaskId != null) {
      const id = this.updateTaskId;
      this.taskService.GetTaskById(id).subscribe(data => {
        this.ngChangesId = true;
        this.taskItem = data;
      })
    }

  }

  hideModal() {
    this.ngChangesId = false;
    this.closeModal.emit();
  }

  updateTask(taskItem: TaskItem) {
    if(taskItem.id)
      this.taskService.UpdateTask(taskItem.id, taskItem).subscribe(data => {
        this.hideModal();
        window.location.reload();
      })
  }


}
