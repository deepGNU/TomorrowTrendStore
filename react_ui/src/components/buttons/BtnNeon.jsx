import React from 'react'
import './Buttons.css'

const BtnNeon = ({ text, onClick, className = '', disabled = false }) => {
    return (
        <button
            className={'btn-neon-card ' + className}
            onClick={onClick}
            disabled={disabled}
        >
            {text}
        </button>
    )
}

export default BtnNeon