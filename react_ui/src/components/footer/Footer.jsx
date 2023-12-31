import './Footer.css'
import React from 'react'

const Footer = () => {
    return (
        <footer className="retrowave-footer">
            <div className="footer-content">
                <div className="contact-info">
                    <h3>Contact Us</h3>
                    <p>Email: contact@electronicsstore.com</p>
                    <p>Phone: 123-456-7890</p>
                </div>
                <div className="social-links">
                    <h3>Follow Us</h3>
                    <ul>
                        <li><a href="/" className="social-icon facebook">Facebook</a></li>
                        <li><a href="/" className="social-icon twitter">Twitter</a></li>
                        <li><a href="/" className="social-icon instagram">Instagram</a></li>
                    </ul>
                </div>
            </div>
        </footer>
    )
}

export default Footer