export const API_BASE_URL = process.env.NEXT_PUBLIC_API_URL || 'http://localhost:5126';


export const API_ENDPOINTS = {
  projects: `${API_BASE_URL}/api/projects`,
  categories: `${API_BASE_URL}/api/categories`,
  testimonials: `${API_BASE_URL}/api/testimonials`,
  contact: `${API_BASE_URL}/api/contact`,
  auth: {
    login: `${API_BASE_URL}/api/auth/login`,
  },
};
