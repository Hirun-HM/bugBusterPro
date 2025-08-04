'use client';

import { useState, useEffect } from 'react';
import { Star, Quote, User } from 'lucide-react';
import { API_ENDPOINTS } from '@/lib/api';

interface Testimonial {
  id: number;
  clientName: string;
  clientCompany: string;
  clientPosition: string;
  content: string;
  rating: number;
  clientImageUrl: string;
  isApproved: boolean;
  createdAt: string;
  projectId: number;
}

export default function TestimonialsPage() {
  const [testimonials, setTestimonials] = useState<Testimonial[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetchTestimonials();
  }, []);

  const fetchTestimonials = async () => {
    try {
      const response = await fetch(API_ENDPOINTS.testimonials);
      const data = await response.json();
      setTestimonials(data);
    } catch (error) {
      console.error('Error fetching testimonials:', error);
    } finally {
      setLoading(false);
    }
  };

  const renderStars = (rating: number) => {
    return Array.from({ length: 5 }, (_, i) => (
      <Star
        key={i}
        className={`h-5 w-5 ${
          i < rating ? 'text-yellow-400 fill-current' : 'text-gray-300'
        }`}
      />
    ));
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
      {/* Hero Section */}
      <section className="bg-gradient-to-r from-blue-600 to-purple-700 text-white py-20">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="text-center">
            <h1 className="text-4xl md:text-5xl font-bold mb-6">
              What Our Clients Say
            </h1>
            <p className="text-xl text-blue-100 max-w-3xl mx-auto">
              Don&apos;t just take our word for it. Hear from our satisfied clients who have 
              experienced our bug-fixing expertise firsthand.
            </p>
          </div>
        </div>
      </section>

      {/* Stats Section */}
      <section className="py-16 bg-white">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          <div className="grid grid-cols-1 md:grid-cols-4 gap-8">
            <div className="text-center">
              <div className="text-4xl font-bold text-blue-600 mb-2">500+</div>
              <div className="text-gray-600">Bugs Fixed</div>
            </div>
            <div className="text-center">
              <div className="text-4xl font-bold text-blue-600 mb-2">100+</div>
              <div className="text-gray-600">Happy Clients</div>
            </div>
            <div className="text-center">
              <div className="text-4xl font-bold text-blue-600 mb-2">4.9</div>
              <div className="text-gray-600">Average Rating</div>
            </div>
            <div className="text-center">
              <div className="text-4xl font-bold text-blue-600 mb-2">24/7</div>
              <div className="text-gray-600">Support Available</div>
            </div>
          </div>
        </div>
      </section>

      {/* Testimonials Grid */}
      <section className="py-16">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
          {testimonials.length === 0 ? (
            <div className="text-center py-12">
              <Quote className="h-16 w-16 text-gray-400 mx-auto mb-4" />
              <h3 className="text-xl font-semibold text-gray-600 mb-2">No testimonials yet</h3>
              <p className="text-gray-500">Check back later for client feedback and reviews.</p>
            </div>
          ) : (
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
              {testimonials.map((testimonial) => (
                <div
                  key={testimonial.id}
                  className="bg-white rounded-lg shadow-md hover:shadow-lg transition-shadow p-8"
                >
                  {/* Quote Icon */}
                  <div className="flex justify-center mb-6">
                    <div className="p-3 bg-blue-100 rounded-full">
                      <Quote className="h-6 w-6 text-blue-600" />
                    </div>
                  </div>

                  {/* Rating */}
                  <div className="flex justify-center gap-1 mb-4">
                    {renderStars(testimonial.rating)}
                  </div>

                  {/* Testimonial Text */}
                  <blockquote className="text-gray-700 text-center mb-6 italic">
                    &quot;{testimonial.content}&quot;
                  </blockquote>

                  {/* Client Info */}
                  <div className="text-center border-t pt-6">
                    <div className="flex justify-center mb-3">
                      <div className="w-12 h-12 bg-gradient-to-r from-blue-500 to-purple-600 rounded-full flex items-center justify-center">
                        <User className="h-6 w-6 text-white" />
                      </div>
                    </div>
                    <h4 className="font-semibold text-gray-900">{testimonial.clientName}</h4>
                    <p className="text-gray-600 text-sm">{testimonial.clientCompany}</p>
                    {testimonial.clientPosition && (
                      <p className="text-gray-500 text-sm mt-1">
                        {testimonial.clientPosition}
                      </p>
                    )}
                    <p className="text-gray-400 text-xs mt-2">
                      {new Date(testimonial.createdAt).toLocaleDateString()}
                    </p>
                  </div>
                </div>
              ))}
            </div>
          )}
        </div>
      </section>

      {/* CTA Section */}
      <section className="py-16 bg-gradient-to-r from-blue-600 to-purple-700">
        <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 text-center">
          <h2 className="text-3xl font-bold text-white mb-4">
            Ready to Join Our Happy Clients?
          </h2>
          <p className="text-xl text-blue-100 mb-8 max-w-2xl mx-auto">
            Let us help you fix your bugs and improve your software. 
            Contact us today for a free consultation.
          </p>
          <a
            href="/contact"
            className="inline-block bg-white text-blue-600 px-8 py-4 rounded-lg font-semibold hover:bg-gray-100 transition-colors"
          >
            Get Started Now
          </a>
        </div>
      </section>
    </div>
  );
}
