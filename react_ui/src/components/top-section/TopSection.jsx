import './TopSection.css'
import React from 'react'
import SearchBar from '../../components/search-bar/SearchBar'
import Filter from '../../components/filter/Filter'
import { useDispatch } from 'react-redux'
import { getProductsByQueryAPI } from '../../api/resources/products'
import { getProductsByFilterAPI } from '../../api/resources/products'

const TopSection = () => {
    const dispatch = useDispatch()

    const handleSearchSubmit = (searchTerm) => {
        getProductsByQueryAPI(dispatch, searchTerm)
    }

    const handleFilterSubmit = (maxPrice, minRating) => {
        getProductsByFilterAPI(dispatch, maxPrice, minRating)
    }

    return (
        <div className='top-section'>
            <SearchBar onSubmit={handleSearchSubmit} />
            <Filter onSubmit={handleFilterSubmit} />
        </div>
    )
}

export default TopSection