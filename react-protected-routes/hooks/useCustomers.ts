"use client"

import { useState, useEffect, useCallback } from "react"

export interface Customer {
  id: string
  name: string
  email: string
  company: string
  status: "active" | "inactive" | "pending"
}

export const useCustomers = () => {
  const [customers, setCustomers] = useState<Customer[]>([])
  const [loading, setLoading] = useState<boolean>(true)
  const [error, setError] = useState<string | null>(null)

  const fetchCustomers = useCallback(async () => {
    try {
      setLoading(true)
      setError(null)

      // Simulate API call - replace with actual API endpoint
      const response = await fetch("/api/customers")

      if (!response.ok) {
        throw new Error(`HTTP error! status: ${response.status}`)
      }

      const data: Customer[] = await response.json()
      setCustomers(data)
    } catch (err) {
      setError(err instanceof Error ? err.message : "An error occurred")
      // Fallback stub data for development
      setCustomers([
        {
          id: "1",
          name: "John Doe",
          email: "john.doe@example.com",
          company: "Acme Corp",
          status: "active",
        },
        {
          id: "2",
          name: "Jane Smith",
          email: "jane.smith@techsolutions.com",
          company: "Tech Solutions Inc",
          status: "pending",
        },
        {
          id: "3",
          name: "Bob Johnson",
          email: "bob.johnson@globaltech.com",
          company: "Global Tech Ltd",
          status: "inactive",
        },
      ])
    } finally {
      setLoading(false)
    }
  }, [])

  useEffect(() => {
    fetchCustomers()
  }, [fetchCustomers])

  return {
    customers,
    loading,
    error,
    refetch: fetchCustomers,
  }
}
