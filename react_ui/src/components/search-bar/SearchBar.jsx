import './SearchBar.css'
import React from 'react'
import { useState } from 'react'
import { FaSearch as SearchIcon } from "react-icons/fa";

const SearchBar = ({ onSubmit }) => {
    const [searchTerm, setSearchTerm] = useState('')

    const handleChange = (e) => {
        setSearchTerm(e.target.value)
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        onSubmit(searchTerm);
        setSearchTerm('');
    }

    return (
        <form
            className='search-bar'
            onSubmit={handleSubmit}
        >
            <input
                type="text"
                placeholder='Search'
                value={searchTerm}
                onChange={handleChange}
            />
            <button type='submit'>
                <SearchIcon />
            </button>
        </form>
    )
}

export default SearchBar