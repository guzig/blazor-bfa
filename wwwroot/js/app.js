// GSAP Animations for Blazor
// Include GSAP in your index.html: <script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/3.12.2/gsap.min.js"></script>
// <script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/3.12.2/ScrollTrigger.min.js"></script>

// Scroll to section with smooth animation
window.scrollToSection = function (sectionId) {
    const element = document.getElementById(sectionId);
    if (element) {
        element.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }
};

// Scroll Interop
window.scrollInterop = {
    scrollToElement: function (selector) {
        const element = document.querySelector(selector);
        if (element) {
            element.scrollIntoView({ behavior: 'smooth' });
        }
    }
};

// Navbar Interop
window.navbarInterop = {
    dotNetRef: null,
    
    initialize: function (dotNetRef) {
        this.dotNetRef = dotNetRef;
        
        const handleScroll = () => {
            const isScrolled = window.scrollY > 50;
            dotNetRef.invokeMethodAsync('SetScrolled', isScrolled);
        };
        
        window.addEventListener('scroll', handleScroll, { passive: true });
        handleScroll(); // Check initial state
        
        this.handleScroll = handleScroll;
    },
    
    dispose: function () {
        if (this.handleScroll) {
            window.removeEventListener('scroll', this.handleScroll);
        }
        this.dotNetRef = null;
    }
};

// Hero Interop
window.heroInterop = {
    animate: function (headingRef, subheadingRef, ctaRef) {
        if (typeof gsap === 'undefined') return;
        
        gsap.fromTo(headingRef, 
            { y: 40, opacity: 0 },
            { y: 0, opacity: 1, duration: 0.8, delay: 0.2, ease: 'power3.out' }
        );
        
        gsap.fromTo(subheadingRef,
            { y: 30, opacity: 0 },
            { y: 0, opacity: 1, duration: 0.7, delay: 0.4, ease: 'power3.out' }
        );
        
        gsap.fromTo(ctaRef,
            { scale: 0.9, opacity: 0 },
            { scale: 1, opacity: 1, duration: 0.5, delay: 0.6, ease: 'power2.out' }
        );
    }
};

// About Interop
window.aboutInterop = {
    animate: function (sectionRef, imageRef, contentRef) {
        if (typeof gsap === 'undefined' || typeof ScrollTrigger === 'undefined') return;
        
        gsap.registerPlugin(ScrollTrigger);
        
        gsap.fromTo(imageRef,
            { x: -50, opacity: 0 },
            {
                x: 0,
                opacity: 1,
                duration: 0.8,
                ease: 'power3.out',
                scrollTrigger: {
                    trigger: sectionRef,
                    start: 'top 70%',
                    toggleActions: 'play none none none'
                }
            }
        );
        
        gsap.fromTo(contentRef,
            { x: 50, opacity: 0 },
            {
                x: 0,
                opacity: 1,
                duration: 0.8,
                ease: 'power3.out',
                scrollTrigger: {
                    trigger: sectionRef,
                    start: 'top 70%',
                    toggleActions: 'play none none none'
                }
            }
        );
    }
};

// Stat Circle Interop
window.statCircleInterop = {
    animate: function (circleRef, percentage, delay) {
        if (typeof gsap === 'undefined' || typeof ScrollTrigger === 'undefined') return;
        
        gsap.registerPlugin(ScrollTrigger);
        
        const circumference = 2 * Math.PI * 45;
        const offset = circumference - (percentage / 100) * circumference;
        
        gsap.fromTo(circleRef,
            { strokeDashoffset: circumference },
            {
                strokeDashoffset: offset,
                duration: 1.5,
                delay: delay / 1000,
                ease: 'power2.out',
                scrollTrigger: {
                    trigger: circleRef,
                    start: 'top 80%',
                    toggleActions: 'play none none none'
                }
            }
        );
    }
};

// Services Interop
window.servicesInterop = {
    animateHeader: function (headerRef) {
        if (typeof gsap === 'undefined' || typeof ScrollTrigger === 'undefined') return;
        
        gsap.registerPlugin(ScrollTrigger);
        
        gsap.fromTo(headerRef,
            { y: 30, opacity: 0 },
            {
                y: 0,
                opacity: 1,
                duration: 0.6,
                ease: 'power3.out',
                scrollTrigger: {
                    trigger: headerRef,
                    start: 'top 80%',
                    toggleActions: 'play none none none'
                }
            }
        );
    }
};

// Service Card Interop
window.serviceCardInterop = {
    animate: function (cardRef, index) {
        if (typeof gsap === 'undefined' || typeof ScrollTrigger === 'undefined') return;
        
        gsap.registerPlugin(ScrollTrigger);
        
        gsap.fromTo(cardRef,
            { y: 40, opacity: 0 },
            {
                y: 0,
                opacity: 1,
                duration: 0.6,
                delay: index * 0.1,
                ease: 'power3.out',
                scrollTrigger: {
                    trigger: cardRef,
                    start: 'top 85%',
                    toggleActions: 'play none none none'
                }
            }
        );
    }
};

// Projects Interop
window.projectsInterop = {
    animate: function (headerRef, carouselRef) {
        if (typeof gsap === 'undefined' || typeof ScrollTrigger === 'undefined') return;
        
        gsap.registerPlugin(ScrollTrigger);
        
        gsap.fromTo(headerRef,
            { y: 30, opacity: 0 },
            {
                y: 0,
                opacity: 1,
                duration: 0.6,
                ease: 'power3.out',
                scrollTrigger: {
                    trigger: headerRef,
                    start: 'top 80%',
                    toggleActions: 'play none none none'
                }
            }
        );
        
        gsap.fromTo(carouselRef,
            { opacity: 0 },
            {
                opacity: 1,
                duration: 0.8,
                delay: 0.3,
                ease: 'power2.out',
                scrollTrigger: {
                    trigger: carouselRef,
                    start: 'top 80%',
                    toggleActions: 'play none none none'
                }
            }
        );
    },
    
    scroll: function (carouselRef, direction) {
        const cardWidth = 280;
        const scrollAmount = cardWidth * 2;
        
        if (direction === 'left') {
            carouselRef.scrollBy({ left: -scrollAmount, behavior: 'smooth' });
        } else {
            carouselRef.scrollBy({ left: scrollAmount, behavior: 'smooth' });
        }
    },
    
    scrollToDot: function (carouselRef, dotIndex) {
        const cardWidth = 280;
        const scrollAmount = cardWidth * 4 * dotIndex;
        carouselRef.scrollTo({ left: scrollAmount, behavior: 'smooth' });
    },
    
    getScrollState: function (carouselRef) {
        const scrollLeft = carouselRef.scrollLeft;
        const maxScroll = carouselRef.scrollWidth - carouselRef.clientWidth;
        const canScrollLeft = scrollLeft > 0;
        const cardWidth = 280;
        const currentDot = Math.floor(scrollLeft / (cardWidth * 4));
        
        return {
            scrollLeft: scrollLeft,
            canScrollLeft: canScrollLeft,
            currentDot: currentDot
        };
    }
};

// Testimonials Interop
window.testimonialsInterop = {
    animate: function (headerRef) {
        if (typeof gsap === 'undefined' || typeof ScrollTrigger === 'undefined') return;
        
        gsap.registerPlugin(ScrollTrigger);
        
        gsap.fromTo(headerRef,
            { y: 30, opacity: 0 },
            {
                y: 0,
                opacity: 1,
                duration: 0.6,
                ease: 'power3.out',
                scrollTrigger: {
                    trigger: headerRef,
                    start: 'top 80%',
                    toggleActions: 'play none none none'
                }
            }
        );
    }
};

// Contact Interop
window.contactInterop = {
    animate: function (headerRef, infoRef, formRef) {
        if (typeof gsap === 'undefined' || typeof ScrollTrigger === 'undefined') return;
        
        gsap.registerPlugin(ScrollTrigger);
        
        gsap.fromTo(headerRef,
            { y: 30, opacity: 0 },
            {
                y: 0,
                opacity: 1,
                duration: 0.6,
                ease: 'power3.out',
                scrollTrigger: {
                    trigger: headerRef,
                    start: 'top 80%',
                    toggleActions: 'play none none none'
                }
            }
        );
        
        const infoCards = infoRef.querySelectorAll('.info-card, .map-placeholder');
        gsap.fromTo(infoCards,
            { y: 30, opacity: 0 },
            {
                y: 0,
                opacity: 1,
                duration: 0.5,
                stagger: 0.1,
                ease: 'power3.out',
                scrollTrigger: {
                    trigger: infoRef,
                    start: 'top 70%',
                    toggleActions: 'play none none none'
                }
            }
        );
        
        gsap.fromTo(formRef,
            { x: -30, opacity: 0 },
            {
                x: 0,
                opacity: 1,
                duration: 0.6,
                delay: 0.3,
                ease: 'power3.out',
                scrollTrigger: {
                    trigger: formRef,
                    start: 'top 70%',
                    toggleActions: 'play none none none'
                }
            }
        );
    },
    
    showToast: function (title, message) {
        // Simple toast notification
        const toast = document.createElement('div');
        toast.style.cssText = `
            position: fixed;
            top: 20px;
            left: 50%;
            transform: translateX(-50%);
            background: #0070a0;
            color: white;
            padding: 1rem 2rem;
            border-radius: 0.5rem;
            box-shadow: 0 10px 30px rgba(0, 0, 0, 0.2);
            z-index: 9999;
            animation: slideDown 0.3s ease-out;
        `;
        toast.innerHTML = `<strong>${title}</strong><br>${message}`;
        document.body.appendChild(toast);
        
        setTimeout(() => {
            toast.style.animation = 'slideUp 0.3s ease-out';
            setTimeout(() => toast.remove(), 300);
        }, 3000);
    }
};

// Add toast animations
const style = document.createElement('style');
style.textContent = `
    @keyframes slideDown {
        from { transform: translateX(-50%) translateY(-100%); opacity: 0; }
        to { transform: translateX(-50%) translateY(0); opacity: 1; }
    }
    @keyframes slideUp {
        from { transform: translateX(-50%) translateY(0); opacity: 1; }
        to { transform: translateX(-50%) translateY(-100%); opacity: 0; }
    }
`;
document.head.appendChild(style);
