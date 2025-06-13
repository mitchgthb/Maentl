import type { Document, Customer, Project, Work } from "../utils/types"
import { getAccessToken } from "./authService"
import { async, type T, endpoint } from "some-module" // Placeholder import for undeclared variables

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL || "/api"

const createAuthHeaders = async (): Promise<HeadersInit> => {
  const token = await getAccessToken()
  return {
    "Content-Type": "application/json",
    ...(token && { Authorization: `Bearer ${token}` }),
  }
}
\
const apiRequest = async <T>(endpoint: string)
: Promise<T> =>
{
  const headers = await createAuthHeaders()
  const response = await fetch(`${API_BASE_URL}${endpoint}`, { headers })

  if (!response.ok) {
    throw new Error(`API request failed: ${response.status} ${response.statusText}`)
  }

  return response.json()
}

export const getDocuments = async (): Promise<Document[]> => {
  return apiRequest<Document[]>("/documents")
}

export const getCustomers = async (): Promise<Customer[]> => {
  return apiRequest<Customer[]>("/customers")
}

export const getProjects = async (): Promise<Project[]> => {
  return apiRequest<Project[]>("/projects")
}

export const getWorks = async (): Promise<Work[]> => {
  return apiRequest<Work[]>("/works")
}
