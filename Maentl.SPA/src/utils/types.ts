export interface Document {
  id: string
  name: string
  type: string
  createdDate: string
  status: "active" | "archived" | "draft"
  size?: number
  author?: string
}

export interface Customer {
  id: string
  name: string
  email: string
  company: string
  status: "active" | "inactive" | "pending"
  phone?: string
  address?: string
  createdDate?: string
}

export interface Project {
  id: string
  name: string
  description: string
  startDate: string
  endDate?: string
  status: "planning" | "in-progress" | "completed" | "on-hold"
  budget?: number
  manager?: string
}

export interface Work {
  id: string
  title: string
  description?: string
  assignee: string
  dueDate: string
  priority: "low" | "medium" | "high" | "urgent"
  status: "todo" | "in-progress" | "review" | "completed"
  projectId?: string
  estimatedHours?: number
}
