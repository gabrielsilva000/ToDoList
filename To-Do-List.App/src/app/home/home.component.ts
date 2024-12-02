import { Component, OnInit } from '@angular/core';
import { TaskService } from '../services/task.service';
import { TaskItem } from '../models/task.item.model';

@Component({
  selector: 'app-home',
  standalone: false,

  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  taskItens: TaskItem[] = [];
  showModalAdd: boolean = false;
  showModalUpdate: boolean = false;
  updateTaskId?: number;
  currentPage = 1;

  constructor( private taskService: TaskService){}

  ngOnInit(): void {
    this.taskService.GetTasks().subscribe(data => {
      const dados = data;

      dados.map((item) => {
        item.dateCreation = new Date(item.dateCreation!).toLocaleDateString('pt-BR')
        item.changeDate = new Date(item.changeDate!).toLocaleDateString('pt-BR')
      })

      this.taskItens = dados;

    });
  }

  displayModalAdd() {
    this.showModalAdd = true;
  }

  closeModalAdd() {
    this.showModalAdd = false;
  }

  displayModalUpdate(id?: number) {
    this.updateTaskId = id;
    this.showModalUpdate = true;
  }

  closeModalUpdate() {
    this.showModalUpdate = false;
  }

  updateTask(taskItem: TaskItem) {
    taskItem.isCompleted = true;
    taskItem.dateCreation = new Date().toISOString();
    taskItem.changeDate = new Date().toISOString();
    if(taskItem.id){
      this.taskService.UpdateTask(taskItem.id, taskItem).subscribe(data => {
        window.location.reload();
      })
    }
  }

  deleteTask(id?: number) {
    if(id != null)
      this.taskService.DeleteTask(id).subscribe(data => {
        window.location.reload();
      })
  }

}
