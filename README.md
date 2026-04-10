# Place — Find Your Next Experience

![Hugo version](https://img.shields.io/badge/Hugo-v0.159.2%2Bextended-ff4088?style=flat&logo=hugo)
![License](https://img.shields.io/badge/License-MIT-blue.svg)

**Place** is an event discovery platform designed for young adults who want to go out, learn something new, or connect with others — but don’t know where to start. This repository contains the full Hugo source code for the Place website.

> 🚀 Live demo: [place.osscameroon.com](https://place.osscameroon.com)

---

## ✨ Features

- 📤 Share events, add to calendar, and view original source  
- 📱 Fully responsive — works on desktop, tablet, and mobile  
- ⚡ Built with Hugo (extended) for lightning-fast static generation  

---

## 🛠️ Built With

- [Hugo v0.159.2+extended](https://gohugo.io/)  
- HTML5 / CSS3 / JavaScript  
- [Tailwind CSS](https://tailwindcss.com/)  

---

## 📦 Getting Started

### Prerequisites

- [Hugo extended](https://gohugo.io/installation/) v0.159.2 or higher  
- Git

### Installation

1. Clone the repository  
   ```bash
   git clone https://github.com/osscameroon/place.git
   cd place
   ```

2. Run the development server  
   ```bash
   hugo server -DF
   ```

3. Open your browser at `http://localhost:1313`

### Build for Production

```bash
hugo --minify -F
```

The static site will be generated in the `public/` directory.

---

## 📂 Project Structure

```
place/
├── assets/          # SCSS, JS, images
├── content/         # Event pages and site content
│   └── posts/       # Individual event markdown files
├── data/            # External data (if any)
├── layouts/         # HTML templates
├── static/          # Static files (favicons, robots.txt)
├── hugo.toml        # Hugo configuration
└── theme.toml       # Theme metadata (if using as a theme)
```

---

## 🧩 Adding Events

Events are stored as markdown files in `content/events/`. Example:

```yaml
---
title: "LibreLocal Meetup Douala - Free Software Community Gathering"
date: 2026-04-11T13:00:00+01:00
slug: /librelocal-douala-2026/
description: Free Software community meetup in Douala to discuss productivity using free software, bilingual event in French and English
image: http://static.fsf.org/nosvn/stickers/fsf.svg
caption: LibreLocal meetup gathering for free software community
location: "SmartWork Co-Workspace, near Eneo Ndokoti, Douala, Cameroon"
categories:
  - workshop
  - training
tags:
  - free software
  - productivity
  - technology
  - douala
  - cameroon
  - open source
  - feature
draft: false
---

**Start Date & Time:** April 11, 2026 at 1:00 PM (13:00 WAT)

**End Date & Time:** April 11, 2026 at 2:00 PM (14:00 WAT)

**Exact Location:** SmartWork Co-Workspace, near Eneo Ndokoti, Douala, Cameroon (GPS: 4.0413807, 9.7344161)

**Registration:** https://form.jotform.com/260934830045051

Join the free software community in Douala for an inspiring meetup focused on gaining productivity using free software. This volunteer-organized community gathering is part of the LibreLocal initiative by the Free Software Foundation. The event will discuss how free software tools can enhance professional productivity and features interactive discussions. Bilingual environment (French & English) welcomed.

**Learn More:** https://www.fsf.org/events/meetup-2026-04-11-duoala-cameroon

**Source:** https://www.fsf.org
```

Each event automatically appears in the grid with interaction buttons (share, calendar, tags).

---

## 🚀 Deployment

The site is static and can be deployed anywhere:

- **Netlify** / **Vercel** – Connect your GitHub repo and set build command to `hugo -F --minify`
- **GitHub Pages** – Use Hugo’s built-in GitHub Actions workflow
- **Any static hosting** – Upload the `public/` folder

---

## 🤝 Contributing

Contributions are welcome! Please open an issue or pull request for:

- New event categories
- UI/UX improvements
- Accessibility fixes
- Performance optimizations
- Localizations

---

## 📄 License

This project is licensed under the MIT License — see the [LICENSE](LICENSE) file for details.

---

## 💬 Acknowledgments

- Inspired by the need for a cleaner, more social event discovery platform  
- Built with ❤️  for young adults ready to explore their city

---

**Your next story is waiting.**  
*From quiet workshops to crowded meetups, every event on Place is a chance to grow, meet someone new, or just break your routine.*
