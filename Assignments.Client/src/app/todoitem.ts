export type TaskType = {
  id: number;
  name: string;
};
export interface TodoItem {
  id: number;
  name: string;
  description: string;
  isArchived: boolean;
  isRepeating: boolean;
  taskType: TaskType;
  startDate: string;
  dueDate: string;
  completeDate: string;
}
