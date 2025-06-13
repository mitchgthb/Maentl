// src/services/api.ts

import type { Document, Customer, Project, Work } from "../utils/types"
import { getAccessToken } from "./authService"

const API_BASE_URL = import.meta.env.VITE_API_BASE_URL ?? "http://localhost:5145/api"

async function createAuthHeaders(): Promise<HeadersInit> {
  const token = await getAccessToken()
  return {
    "Content-Type": "application/json",
    ...(token ? { Authorization: `Bearer ${token}` } : {}),
  }
}

async function apiRequest<T>(path: string): Promise<T> {
  const headers = await createAuthHeaders()
  const res = await fetch(`${API_BASE_URL}${path}`, { headers })
  if (!res.ok) {
    throw new Error(`API error ${res.status}: ${res.statusText}`)
  }
  return res.json() as Promise<T>
}

export const getDocuments = (): Promise<Document[]> =>
  apiRequest<Document[]>("/documents")

export const getCustomers = (): Promise<Customer[]> =>
  apiRequest<Customer[]>("/customers")

export const getProjects = (): Promise<Project[]> =>
  apiRequest<Project[]>("/projects")

export const getWorks = (): Promise<Work[]> =>
  apiRequest<Work[]>("/workentries")
