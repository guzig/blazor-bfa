// GSAP Animations for Blazor
// Include GSAP in your index.html: <script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/3.12.2/gsap.min.js"></script>
// <script src="https://cdnjs.cloudflare.com/ajax/libs/gsap/3.12.2/ScrollTrigger.min.js"></script>

// Scroll to section with smooth animation
window.scrollToSection = function (sectionId) {
    const element = document.getElementById(sectionId);
    if (!element) return;
    // Use the snap-main scroll container if present, else fallback to scrollIntoView
    const container = document.querySelector('main.snap-main');
    if (container) {
        container.scrollTo({ top: element.offsetTop, behavior: 'smooth' });
    } else {
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

// Configure GSAP ScrollTrigger to use main.snap-main as scroller
document.addEventListener('DOMContentLoaded', function () {
    if (typeof gsap !== 'undefined' && typeof ScrollTrigger !== 'undefined') {
        gsap.registerPlugin(ScrollTrigger);
        const snapMain = document.querySelector('main.snap-main');
        if (snapMain) {
            ScrollTrigger.defaults({ scroller: snapMain });
        }
    }
});

// Navbar Interop
window.navbarInterop = {
    dotNetRef: null,

    initialize: function (dotNetRef) {
        this.dotNetRef = dotNetRef;

        const getScrollTop = () => {
            const container = document.querySelector('main.snap-main');
            return container ? container.scrollTop : window.scrollY;
        };

        const handleScroll = () => {
            const isScrolled = getScrollTop() > 50;
            dotNetRef.invokeMethodAsync('SetScrolled', isScrolled);
        };

        const container = document.querySelector('main.snap-main');
        const target = container || window;
        target.addEventListener('scroll', handleScroll, { passive: true });
        handleScroll();

        this.handleScroll = handleScroll;
        this.scrollTarget = target;
    },

    dispose: function () {
        if (this.handleScroll && this.scrollTarget) {
            this.scrollTarget.removeEventListener('scroll', this.handleScroll);
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

// Portfolio Marquee — auto-scroll with manual arrow control
window.portfolioMarquee = {
    _raf: null,
    _outer: null,
    _halfWidth: 0,
    _speed: 0.6, // px per frame (~60fps → ~56s per loop)

    init: function () {
        const outer = document.querySelector('.projects-marquee-outer');
        if (!outer) return;
        this._outer = outer;

        // Wait one extra frame so layout is complete
        requestAnimationFrame(() => {
            const track = outer.querySelector('.projects-marquee-track');
            if (!track) return;
            this._halfWidth = track.scrollWidth / 2;
            this._tick();
        });
    },

    _tick: function () {
        const self = window.portfolioMarquee;
        if (!self._outer) return;
        if (!self._outer.matches(':hover')) {
            self._outer.scrollLeft += self._speed;
            if (self._outer.scrollLeft >= self._halfWidth) {
                self._outer.scrollLeft = 0;
            }
        }
        self._raf = requestAnimationFrame(self._tick);
    },

    scroll: function (direction) {
        if (!this._outer) return;
        const amount = (224 + 16) * 3;
        this._outer.scrollBy({ left: direction === 'left' ? -amount : amount, behavior: 'smooth' });
    },

    dispose: function () {
        if (this._raf) cancelAnimationFrame(this._raf);
        this._outer = null;
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
        const el = document.getElementById('projects-rail');
        if (!el) return;
        const amount = (224 + 16) * 3;
        el.scrollBy({ left: direction === 'left' ? -amount : amount, behavior: 'smooth' });
    },

    scrollToDot: function (carouselRef, dotIndex) {
        const cardWidth = 280;
        const scrollAmount = cardWidth * 4 * dotIndex;
        carouselRef.scrollTo({ left: scrollAmount, behavior: 'smooth' });
    },

    getScrollState: function (carouselRef) {
        const scrollLeft = carouselRef.scrollLeft;
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

// Shared page motion and media bootstrap
window.uiRuntime = {
    _revealObserver: null,
    _watchersStarted: false,

    initRevealAnimations: function () {
        const items = document.querySelectorAll('.reveal');
        if (!items.length) {
            return;
        }

        if (!('IntersectionObserver' in window)) {
            items.forEach((el) => el.classList.add('in-view'));
            return;
        }

        if (!this._revealObserver) {
            this._revealObserver = new IntersectionObserver((entries, obs) => {
                entries.forEach((entry) => {
                    if (entry.isIntersecting) {
                        entry.target.classList.add('in-view');
                        obs.unobserve(entry.target);
                    }
                });
            }, {
                threshold: 0.12,
                rootMargin: '0px 0px -8% 0px'
            });
        }

        items.forEach((el) => {
            if (el.classList.contains('in-view') || el.dataset.revealObserved === '1') {
                return;
            }
            el.dataset.revealObserved = '1';
            this._revealObserver.observe(el);
        });
    },

    revealFallback: function () {
        const viewportLimit = window.innerHeight * 1.2;
        document.querySelectorAll('.reveal:not(.in-view)').forEach((el) => {
            const top = el.getBoundingClientRect().top;
            if (top <= viewportLimit) {
                el.classList.add('in-view');
            }
        });
    },

    ensureAutoplayVideos: function () {
        const videos = document.querySelectorAll('#chi-siamo video, video[data-autoplay="true"]');
        videos.forEach((video) => {
            if (video.dataset.autoplayBound !== '1') {
                video.dataset.autoplayBound = '1';
                video.addEventListener('canplay', () => {
                    video.muted = true;
                    video.defaultMuted = true;
                    const canPlayPromise = video.play();
                    if (canPlayPromise && typeof canPlayPromise.catch === 'function') {
                        canPlayPromise.catch(() => {});
                    }
                });
            }

            video.preload = 'auto';
            video.muted = true;
            video.defaultMuted = true;
            video.playsInline = true;
            video.autoplay = true;
            const playPromise = video.play();
            if (playPromise && typeof playPromise.catch === 'function') {
                playPromise.catch(() => {
                    // Ignore autoplay rejections; user interaction can resume playback.
                });
            }
        });
    },

    startRuntimeWatchers: function () {
        if (this._watchersStarted) {
            return;
        }
        this._watchersStarted = true;

        const run = () => {
            this.initRevealAnimations();
            this.ensureAutoplayVideos();
        };

        run();
        setTimeout(run, 400);
        setTimeout(run, 1200);
        setTimeout(run, 2200);
        setTimeout(() => this.revealFallback(), 2800);

        const root = document.getElementById('app') || document.body;
        const observer = new MutationObserver(() => run());
        observer.observe(root, { childList: true, subtree: true });

        window.addEventListener('scroll', () => this.initRevealAnimations(), { passive: true });
    }
};

document.addEventListener('DOMContentLoaded', () => {
    window.uiRuntime.startRuntimeWatchers();
});
