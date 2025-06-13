"use client"

import { useState, useEffect, useCallback } from "react"

export interface Document {
  id: string
  name: string
  type: string
  createdDate: string
  status: "active" | "archived" | "draft"
}

export const useDocuments = () => {
  const [documents, setDocuments] = useState<Document[]>([])
  const [loading, setLoading] = useState<boolean>(true)
  const [error, setError] = useState<string | null>(null)

  const fetchDocuments = useCallback(async () => {
    try {
      setLoading(true)
      setError(null)

      // Simulate API call - replace with actual API endpoint
      const response = await fetch("/api/documents")

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`)
      }

      const data: Document[] = await response.json()
      setDocuments(data)
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error occurred")
      // Fallback stub data for development
      setDocuments([
        {
          id: "1",
          name: "Project Proposal.pdf",
          type: "PDF",
          createdDate: "2024-01-15T10:00:00Z",
          status: "active",
        },
        {
          id: "2",
          name: "Meeting Notes.docx",
          type: "Word",
          createdDate: "2024-01-14T14:30:00Z",
          status: "draft",
        },
        {
          id: "3",
          name: "Financial Report.xlsx",
          type: "Excel",
          createdDate: "2024-01-13T09:15:00Z",
          status: "archived",
        },
      ])
    } finally {
      setLoading(false)
    }
  }, [])

  useEffect(() => {
    fetchDocuments()
  }, [fetchDocuments])

  return {
    documents,
    loading,
    error,
    refetch: fetchDocuments,
  }
}
