export interface TaskItem {
  id?: number;
  title: string;
  description: string;
  isCompleted: boolean;
  dateCreation?: string;
  changeDate?: string;
}
