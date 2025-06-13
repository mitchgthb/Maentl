"use client"

import { useState, useEffect, useCallback } from "react"

export interface Work {
  id: string
  title: string
  assignee: string
  dueDate: string
  priority: "low" | "medium" | "high" | "urgent"
  status: "todo" | "in-progress" | "review" | "completed"
}

export const useWorks = () => {
  const [works, setWorks] = useState<Work[]>([])
  const [loading, setLoading] = useState<boolean>(true)
  const [error, setError] = useState<string | null>(null)

  const fetchWorks = useCallback(async () => {
    try {
      setLoading(true)
      setError(null)

      // Simulate API call - replace with actual API endpoint
      const response = await fetch("/api/works")

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`)
      }

      const data: Work[] = await response.json()
      setWorks(data)
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error occurred")
      // Fallback stub data for development
      setWorks([
        {
          id: "1",
          title: "Design Homepage Layout",
          assignee: "Alice Johnson",
          dueDate: "2024-01-20T00:00:00Z",
          priority: "high",
          status: "in-progress",
        },
        {
          id: "2",
          title: "Implement User Authentication",
          assignee: "Bob Wilson",
          dueDate: "2024-01-25T00:00:00Z",
          priority: "urgent",
          status: "todo",
        },
        {
          id: "3",
          title: "Code Review - Payment Module",
          assignee: "Carol Davis",
          dueDate: "2024-01-18T00:00:00Z",
          priority: "medium",
          status: "review",
        },
        {
          id: "4",
          title: "Update Documentation",
          assignee: "David Brown",
          dueDate: "2024-01-15T00:00:00Z",
          priority: "low",
          status: "completed",
        },
      ])
    } finally {
      setLoading(false)
    }
  }, [])

  useEffect(() => {
    fetchWorks()
  }, [fetchWorks])

  return {
    works,
    loading,
    error,
    refetch: fetchWorks,
  }
}
