"use client"

import { useState, useEffect, useCallback } from "react"
import { getProjects } from "../services/api"
import type { Project } from "../utils/types"



export const useProjects = () => {
  const [projects, setProjects] = useState<Project[]>([])
  const [loading, setLoading] = useState<boolean>(true)
  const [error, setError] = useState<string | null>(null)

  const fetchProjects = useCallback(async () => {
    try {
      setLoading(true)
      setError(null)
      const data = await getProjects()
      setProjects(data)
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error occurred")
      // Fallback stub data for development
      setProjects([
        {
          id: "1",
          name: "Website Redesign",
          description: "Complete overhaul of company website with modern design and improved UX",
          startDate: "2024-01-01T00:00:00Z",
          status: "in-progress",
        },
        {
          id: "2",
          name: "Mobile App Development",
          description: "Native mobile application for iOS and Android platforms",
          startDate: "2024-02-01T00:00:00Z",
          status: "planning",
        },
        {
          id: "3",
          name: "Database Migration",
          description: "Migration from legacy database system to modern cloud solution",
          startDate: "2023-12-01T00:00:00Z",
          status: "completed",
        },
      ])
    } finally {
      setLoading(false)
    }
  }, [])

  useEffect(() => {
    fetchProjects()
  }, [fetchProjects])

  return {
    projects,
    loading,
    error,
    refresh: fetchProjects,
  }
}
