'use client';

import { useState, useEffect } from 'react';
import { useParams } from 'next/navigation';
import { Bug, Calendar, Tag, CheckCircle, AlertTriangle, ArrowLeft, Code } from 'lucide-react';
import Link from 'next/link';
import { API_ENDPOINTS } from '@/lib/api';

interface Project {
  id: number;
  title: string;
  description: string;
  problemDescription: string;
  solutionDescription: string;
  technologiesUsed: string;
  completedAt: string;
  imageUrl: string;
  category: {
    id: number;
    name: string;
    description: string;
  };
}

export default function ProjectDetailPage() {
  const { id } = useParams();
  const [project, setProject] = useState<Project | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchProject = async () => {
      try {
        const response = await fetch(`${API_ENDPOINTS.projects}/${id}`);
        if (!response.ok) {
          throw new Error('Project not found');
        }
        const data = await response.json();
        setProject(data);
      } catch (error) {
        console.error('Error fetching project:', error);
        setError('Failed to load project details');
      } finally {
        setLoading(false);
      }
    };

    if (id) {
      fetchProject();
    }
  }, [id]);

  if (loading) {
    return (
      <div className="min-h-screen bg-gray-50 flex items-center justify-center">
        <div className="animate-spin rounded-full h-32 w-32 border-b-2 border-blue-600"></div>
      </div>
    );
  }

  if (error || !project) {
    return (
      <div className="min-h-screen bg-gray-50 flex items-center justify-center">
        <div className="text-center">
          <Bug className="h-16 w-16 text-gray-400 mx-auto mb-4" />
          <h1 className="text-2xl font-semibold text-gray-900 mb-2">Project Not Found</h1>
          <p className="text-gray-600 mb-6">{error || 'The project you&apos;re looking for doesn&apos;t exist.'}</p>
          <Link
            href="/projects"
            className="inline-flex items-center gap-2 bg-blue-600 text-white px-6 py-3 rounded-lg hover:bg-blue-700 transition-colors"
          >
            <ArrowLeft className="h-4 w-4" />
            Back to Projects
          </Link>
        </div>
      </div>
    );
  }

  return (
    <div className="min-h-screen bg-gray-50">
      {/* Header */}
      <div className="bg-white border-b">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-6">
          <Link
            href="/projects"
            className="inline-flex items-center gap-2 text-blue-600 hover:text-blue-700 mb-4"
          >
            <ArrowLeft className="h-4 w-4" />
            Back to Projects
          </Link>
          <div className="flex flex-col lg:flex-row lg:items-center justify-between gap-4">
            <div>
              <h1 className="text-3xl font-bold text-gray-900">{project.title}</h1>
              <div className="flex flex-wrap items-center gap-4 mt-2 text-sm text-gray-600">
                <div className="flex items-center gap-1">
                  <Calendar className="h-4 w-4" />
                  Completed: {new Date(project.completedAt).toLocaleDateString()}
                </div>
                <div className="flex items-center gap-1">
                  <Tag className="h-4 w-4" />
                  {project.category.name}
                </div>
                <div className="flex items-center gap-1">
                  <Code className="h-4 w-4" />
                  {project.technologiesUsed}
                </div>
              </div>
            </div>
            <div className="flex-shrink-0">
              <span className="inline-flex items-center gap-2 bg-green-100 text-green-800 px-4 py-2 rounded-full">
                <CheckCircle className="h-4 w-4" />
                Resolved
              </span>
            </div>
          </div>
        </div>
      </div>

      {/* Content */}
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 py-12">
        <div className="grid grid-cols-1 lg:grid-cols-3 gap-12">
          {/* Main Content */}
          <div className="lg:col-span-2 space-y-8">
            {/* Project Overview */}
            <section className="bg-white rounded-lg shadow-sm p-8">
              <h2 className="text-2xl font-semibold text-gray-900 mb-4">Project Overview</h2>
              <p className="text-gray-700 leading-relaxed">{project.description}</p>
            </section>

            {/* The Bug */}
            <section className="bg-white rounded-lg shadow-sm p-8">
              <div className="flex items-center gap-3 mb-4">
                <div className="p-2 bg-red-100 rounded-lg">
                  <AlertTriangle className="h-6 w-6 text-red-600" />
                </div>
                <h2 className="text-2xl font-semibold text-gray-900">The Problem</h2>
              </div>
              <div className="bg-red-50 border-l-4 border-red-400 p-6 rounded-r-lg">
                <p className="text-gray-800 leading-relaxed">{project.problemDescription}</p>
              </div>
            </section>

            {/* The Solution */}
            <section className="bg-white rounded-lg shadow-sm p-8">
              <div className="flex items-center gap-3 mb-4">
                <div className="p-2 bg-green-100 rounded-lg">
                  <CheckCircle className="h-6 w-6 text-green-600" />
                </div>
                <h2 className="text-2xl font-semibold text-gray-900">Our Solution</h2>
              </div>
              <div className="bg-green-50 border-l-4 border-green-400 p-6 rounded-r-lg">
                <p className="text-gray-800 leading-relaxed">{project.solutionDescription}</p>
              </div>
            </section>
          </div>

          {/* Sidebar */}
          <div className="space-y-6">
            {/* Project Stats */}
            <div className="bg-white rounded-lg shadow-sm p-6">
              <h3 className="text-lg font-semibold text-gray-900 mb-4">Project Details</h3>
              <div className="space-y-4">
                <div>
                  <div className="text-sm font-medium text-gray-500">Category</div>
                  <p className="text-gray-900">{project.category.name}</p>
                </div>
                <div>
                  <div className="text-sm font-medium text-gray-500">Technology Stack</div>
                  <p className="text-gray-900">{project.technologiesUsed}</p>
                </div>
                <div>
                  <div className="text-sm font-medium text-gray-500">Completion Date</div>
                  <p className="text-gray-900">{new Date(project.completedAt).toLocaleDateString()}</p>
                </div>
                <div>
                  <div className="text-sm font-medium text-gray-500">Status</div>
                  <span className="inline-flex items-center gap-1 text-green-700 font-medium">
                    <CheckCircle className="h-4 w-4" />
                    Resolved
                  </span>
                </div>
              </div>
            </div>

            {/* CTA */}
            <div className="bg-gradient-to-r from-blue-600 to-purple-600 rounded-lg shadow-sm p-6 text-white">
              <h3 className="text-lg font-semibold mb-2">Have a Similar Issue?</h3>
              <p className="text-blue-100 mb-4 text-sm">
                We can help you fix bugs and improve your software. Contact us for a free consultation.
              </p>
              <Link
                href="/contact"
                className="inline-block bg-white text-blue-600 px-4 py-2 rounded-lg font-medium hover:bg-gray-100 transition-colors"
              >
                Get Help Now
              </Link>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
