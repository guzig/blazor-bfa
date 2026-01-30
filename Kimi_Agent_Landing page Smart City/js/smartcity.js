// Smart City Landing Page - JavaScript

// Mobile Navigation Toggle
document.addEventListener('DOMContentLoaded', function() {
    const navToggler = document.getElementById('navToggler');
    const navCollapse = document.getElementById('navCollapse');
    
    if (navToggler && navCollapse) {
        navToggler.addEventListener('click', function() {
            navCollapse.classList.toggle('show');
            const icon = navToggler.querySelector('.material-icons');
            icon.textContent = navCollapse.classList.contains('show') ? 'close' : 'menu';
        });
    }
    
    // Close mobile menu when clicking on a link
    const navLinks = document.querySelectorAll('.nav-link');
    navLinks.forEach(link => {
        link.addEventListener('click', function() {
            navCollapse.classList.remove('show');
            const icon = navToggler.querySelector('.material-icons');
            if (icon) icon.textContent = 'menu';
        });
    });
    
    // Smooth scroll for anchor links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function(e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                const navbarHeight = document.getElementById('navbar')?.offsetHeight || 0;
                const targetPosition = target.getBoundingClientRect().top + window.pageYOffset - navbarHeight - 20;
                window.scrollTo({
                    top: targetPosition,
                    behavior: 'smooth'
                });
            }
        });
    });
    
    // Scroll spy for navigation
    const sections = ['home', 'services', 'features', 'testimonials', 'contact'];
    const navbar = document.getElementById('navbar');
    
    window.addEventListener('scroll', function() {
        // Navbar background
        if (window.pageYOffset > 50) {
            navbar.classList.add('scrolled');
        } else {
            navbar.classList.remove('scrolled');
        }
        
        // Update active section
        let currentSection = 'home';
        const navbarHeight = navbar?.offsetHeight || 0;
        
        sections.forEach(sectionId => {
            const section = document.getElementById(sectionId);
            if (section) {
                const rect = section.getBoundingClientRect();
                if (rect.top <= navbarHeight + 100) {
                    currentSection = sectionId;
                }
            }
        });
        
        // Update active nav link
        navLinks.forEach(link => {
            link.classList.remove('active');
            if (link.getAttribute('href') === '#' + currentSection) {
                link.classList.add('active');
            }
        });
    });
    
    // Animate elements on scroll
    const animateOnScroll = function() {
        const elements = document.querySelectorAll('.service-card, .stat-card, .feature-item, .testimonial-card');
        
        elements.forEach(element => {
            const elementTop = element.getBoundingClientRect().top;
            const elementVisible = 150;
            
            if (elementTop < window.innerHeight - elementVisible) {
                element.style.opacity = '1';
                element.style.transform = 'translateY(0)';
            }
        });
    };
    
    // Set initial state for animated elements
    const animatedElements = document.querySelectorAll('.service-card, .stat-card, .feature-item, .testimonial-card');
    animatedElements.forEach(el => {
        el.style.opacity = '0';
        el.style.transform = 'translateY(30px)';
        el.style.transition = 'opacity 0.6s ease, transform 0.6s ease';
    });
    
    window.addEventListener('scroll', animateOnScroll);
    animateOnScroll(); // Trigger once on load
    
    // Counter animation
    const counters = document.querySelectorAll('[data-count]');
    const animateCounters = function() {
        counters.forEach(counter => {
            const rect = counter.getBoundingClientRect();
            if (rect.top < window.innerHeight && rect.bottom > 0) {
                const target = parseInt(counter.getAttribute('data-count'));
                const duration = 2000;
                const step = target / (duration / 16);
                let current = 0;
                
                const updateCounter = function() {
                    current += step;
                    if (current < target) {
                        counter.textContent = Math.floor(current);
                        requestAnimationFrame(updateCounter);
                    } else {
                        counter.textContent = target;
                    }
                };
                
                updateCounter();
                counter.removeAttribute('data-count'); // Prevent re-animation
            }
        });
    };
    
    window.addEventListener('scroll', animateCounters);
    animateCounters(); // Trigger once on load
    
    // Demo form submission
    const demoForm = document.getElementById('demoForm');
    if (demoForm) {
        demoForm.addEventListener('submit', function(e) {
            e.preventDefault();
            alert('Grazie per la tua richiesta! Ti contatteremo presto per organizzare la demo.');
            const modal = bootstrap.Modal.getInstance(document.getElementById('demoModal'));
            if (modal) modal.hide();
            demoForm.reset();
        });
    }
});
