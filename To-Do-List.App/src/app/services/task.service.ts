import { Injectable } from '@angular/core';
import { environment } from '../../environment/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskItem } from '../models/task.item.model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private apiUrl = `${environment.apiUrl}/Task`

  constructor(private http: HttpClient) { }

  GetTasks(): Observable<TaskItem[]> {
    return this.http.get<TaskItem[]>(this.apiUrl);
  }

  GetTaskById(id: number): Observable<TaskItem> {
    return this.http.get<TaskItem>(`${this.apiUrl}/${id}`)
  }

  UpdateTask(id: number, task: TaskItem): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, task);
  }

  AddTask(taskItem: TaskItem): Observable<TaskItem[]> {
    return this.http.post<TaskItem[]>(`${this.apiUrl}`, taskItem);
  }

  DeleteTask(id: number) {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

}
