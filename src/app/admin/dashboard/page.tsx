'use client';

import { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import Link from 'next/link';
import { 
  LayoutDashboard, 
  FolderOpen, 
  MessageSquare, 
  Mail, 
  LogOut,
  Bug,
  CheckCircle,
  Clock
} from 'lucide-react';
import { API_ENDPOINTS } from '@/lib/api';

interface DashboardStats {
  totalProjects: number;
  completedProjects: number;
  pendingProjects: number;
  totalTestimonials: number;
  pendingContacts: number;
}

interface Project {
  id: number;
  title: string;
  category: { name: string };
  completedDate: string;
}

interface ContactSubmission {
  id: number;
  name: string;
  email: string;
  projectType: string;
  dateSubmitted: string;
}

export default function AdminDashboard() {
  const [stats, setStats] = useState<DashboardStats>({
    totalProjects: 0,
    completedProjects: 0,
    pendingProjects: 0,
    totalTestimonials: 0,
    pendingContacts: 0
  });
  const [recentProjects, setRecentProjects] = useState<Project[]>([]);
  const [recentContacts, setRecentContacts] = useState<ContactSubmission[]>([]);
  const [loading, setLoading] = useState(true);
  const router = useRouter();

  useEffect(() => {
    const token = localStorage.getItem('adminToken');
    if (!token) {
      router.push('/admin');
      return;
    }
    
    fetchDashboardData();
  }, [router]);

  const fetchDashboardData = async () => {
    try {
      const token = localStorage.getItem('adminToken');
      const headers = {
        'Authorization': `Bearer ${token}`,
        'Content-Type': 'application/json'
      };

      // Fetch stats
      const [projectsRes, testimonialsRes, contactsRes] = await Promise.all([
        fetch(API_ENDPOINTS.projects, { headers }),
        fetch(API_ENDPOINTS.testimonials, { headers }),
        fetch(API_ENDPOINTS.contact, { headers })
      ]);

      const projects = await projectsRes.json();
      const testimonials = await testimonialsRes.json();
      const contacts = await contactsRes.json();

      setStats({
        totalProjects: projects.length,
        completedProjects: projects.length, // All projects in our system are completed
        pendingProjects: 0,
        totalTestimonials: testimonials.length,
        pendingContacts: contacts.length
      });

      // Set recent items
      setRecentProjects(projects.slice(0, 5));
      setRecentContacts(contacts.slice(0, 5));
    } catch (error) {
      console.error('Error fetching dashboard data:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleLogout = () => {
    localStorage.removeItem('adminToken');
    router.push('/admin');
  };

  if (loading) {
    return (
      <div className="min-h-screen bg-gray-50 flex items-center justify-center">
        <div className="animate-spin rounded-full h-32 w-32 border-b-2 border-blue-600"></div>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-gray-50">
      {/* Header */}
      <header className="bg-white shadow-sm border-b">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="flex justify-between items-center py-4">
            <div className="flex items-center gap-4">
              <div className="p-2 bg-blue-600 rounded-lg">
                <Bug className="h-6 w-6 text-white" />
              </div>
              <div>
                <h1 className="text-xl font-semibold text-gray-900">BugBusters Pro Admin</h1>
                <p className="text-sm text-gray-600">Manage your projects and content</p>
              </div>
            </div>
            <div className="flex items-center gap-4">
              <Link
                href="/"
                target="_blank"
                className="text-blue-600 hover:text-blue-700 text-sm font-medium"
              >
                View Site
              </Link>
              <button
                onClick={handleLogout}
                className="flex items-center gap-2 text-gray-600 hover:text-gray-900 text-sm font-medium"
              >
                <LogOut className="h-4 w-4" />
                Logout
              </button>
            </div>
          </div>
        </div>
      </header>

      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-8">
        {/* Navigation */}
        <nav className="flex space-x-8 mb-8">
          <Link href="/admin/dashboard" className="flex items-center gap-2 text-blue-600 border-b-2 border-blue-600 pb-2">
            <LayoutDashboard className="h-4 w-4" />
            Dashboard
          </Link>
          <Link href="/admin/projects" className="flex items-center gap-2 text-gray-600 hover:text-gray-900 pb-2">
            <FolderOpen className="h-4 w-4" />
            Projects
          </Link>
          <Link href="/admin/testimonials" className="flex items-center gap-2 text-gray-600 hover:text-gray-900 pb-2">
            <MessageSquare className="h-4 w-4" />
            Testimonials
          </Link>
          <Link href="/admin/contacts" className="flex items-center gap-2 text-gray-600 hover:text-gray-900 pb-2">
            <Mail className="h-4 w-4" />
            Contacts
          </Link>
        </nav>

        {/* Stats Grid */}
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6 mb-8">
          <div className="bg-white rounded-lg shadow-sm p-6">
            <div className="flex items-center justify-between">
              <div>
                <p className="text-sm font-medium text-gray-600">Total Projects</p>
                <p className="text-3xl font-bold text-gray-900">{stats.totalProjects}</p>
              </div>
              <div className="p-3 bg-blue-100 rounded-lg">
                <FolderOpen className="h-6 w-6 text-blue-600" />
              </div>
            </div>
          </div>

          <div className="bg-white rounded-lg shadow-sm p-6">
            <div className="flex items-center justify-between">
              <div>
                <p className="text-sm font-medium text-gray-600">Completed</p>
                <p className="text-3xl font-bold text-green-600">{stats.completedProjects}</p>
              </div>
              <div className="p-3 bg-green-100 rounded-lg">
                <CheckCircle className="h-6 w-6 text-green-600" />
              </div>
            </div>
          </div>

          <div className="bg-white rounded-lg shadow-sm p-6">
            <div className="flex items-center justify-between">
              <div>
                <p className="text-sm font-medium text-gray-600">Testimonials</p>
                <p className="text-3xl font-bold text-purple-600">{stats.totalTestimonials}</p>
              </div>
              <div className="p-3 bg-purple-100 rounded-lg">
                <MessageSquare className="h-6 w-6 text-purple-600" />
              </div>
            </div>
          </div>

          <div className="bg-white rounded-lg shadow-sm p-6">
            <div className="flex items-center justify-between">
              <div>
                <p className="text-sm font-medium text-gray-600">New Contacts</p>
                <p className="text-3xl font-bold text-orange-600">{stats.pendingContacts}</p>
              </div>
              <div className="p-3 bg-orange-100 rounded-lg">
                <Mail className="h-6 w-6 text-orange-600" />
              </div>
            </div>
          </div>
        </div>

        {/* Content Grid */}
        <div className="grid grid-cols-1 lg:grid-cols-2 gap-8">
          {/* Recent Projects */}
          <div className="bg-white rounded-lg shadow-sm">
            <div className="p-6 border-b border-gray-200">
              <div className="flex justify-between items-center">
                <h2 className="text-lg font-semibold text-gray-900">Recent Projects</h2>
                <Link href="/admin/projects" className="text-blue-600 hover:text-blue-700 text-sm font-medium">
                  View All
                </Link>
              </div>
            </div>
            <div className="p-6">
              {recentProjects.length === 0 ? (
                <p className="text-gray-500 text-center py-4">No projects yet</p>
              ) : (
                <div className="space-y-4">
                  {recentProjects.map((project) => (
                    <div key={project.id} className="flex items-center justify-between p-3 bg-gray-50 rounded-lg">
                      <div>
                        <h3 className="font-medium text-gray-900">{project.title}</h3>
                        <p className="text-sm text-gray-600">{project.category.name}</p>
                      </div>
                      <div className="text-right">
                        <p className="text-sm text-gray-500">
                          {new Date(project.completedDate).toLocaleDateString()}
                        </p>
                        <span className="inline-flex items-center gap-1 text-green-600 text-xs">
                          <CheckCircle className="h-3 w-3" />
                          Completed
                        </span>
                      </div>
                    </div>
                  ))}
                </div>
              )}
            </div>
          </div>

          {/* Recent Contacts */}
          <div className="bg-white rounded-lg shadow-sm">
            <div className="p-6 border-b border-gray-200">
              <div className="flex justify-between items-center">
                <h2 className="text-lg font-semibold text-gray-900">Recent Contacts</h2>
                <Link href="/admin/contacts" className="text-blue-600 hover:text-blue-700 text-sm font-medium">
                  View All
                </Link>
              </div>
            </div>
            <div className="p-6">
              {recentContacts.length === 0 ? (
                <p className="text-gray-500 text-center py-4">No contacts yet</p>
              ) : (
                <div className="space-y-4">
                  {recentContacts.map((contact) => (
                    <div key={contact.id} className="flex items-center justify-between p-3 bg-gray-50 rounded-lg">
                      <div>
                        <h3 className="font-medium text-gray-900">{contact.name}</h3>
                        <p className="text-sm text-gray-600">{contact.email}</p>
                        <p className="text-xs text-gray-500">{contact.projectType}</p>
                      </div>
                      <div className="text-right">
                        <p className="text-sm text-gray-500">
                          {new Date(contact.dateSubmitted).toLocaleDateString()}
                        </p>
                        <span className="inline-flex items-center gap-1 text-orange-600 text-xs">
                          <Clock className="h-3 w-3" />
                          New
                        </span>
                      </div>
                    </div>
                  ))}
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
