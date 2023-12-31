import React from 'react'
import './Filter.css'
import { useState, useRef } from 'react'
import { useDispatch } from 'react-redux'
import { filterProducts } from '../../features/products/products-slice'
import BtnNeon from '../buttons/BtnNeon'

const Filter = ({ onSubmit }) => {
    const dispatch = useDispatch()
    const [maxPrice, setMaxPrice] = useState('')
    const [minRating, setMinRating] = useState('')
    const priceRef = useRef()
    const ratingRef = useRef()

    const handleMinPriceChange = (e) => {
        const newMaxPrice = e.target.value
        setMaxPrice(e.target.value)
        dispatch(filterProducts({ maxPrice: newMaxPrice, minRating }))
    }

    const handleMinRatingChange = (e) => {
        setMinRating(e.target.value)
        const newMinRating = e.target.value
        dispatch(filterProducts({ maxPrice, minRating: newMinRating }))
    }

    const handleResetPrice = () => {
        setMaxPrice('')
        dispatch(filterProducts({ maxPrice: null, minRating }))
        priceRef.current.value = ''
    }

    const handleResetRating = () => {
        setMinRating('')
        dispatch(filterProducts({ maxPrice, minRating: null }))
        ratingRef.current.value = ''
    }

    const handleResetAll = () => {
        setMaxPrice('')
        setMinRating('')
        dispatch(filterProducts({ maxPrice: null, minRating: null }))
        priceRef.current.value = ''
        ratingRef.current.value = ''
    }

    return (
        <>
            <div className='filter-wrapper'>
                <div className='neon-sign'>Filter Results</div>
                <div className='filter-div'>
                    <div>
                        <label htmlFor="price">Maximal Price:</label>
                        <input
                            ref={priceRef}
                            type="number"
                            name="price"
                            id="price"
                            min={100}
                            step={100}
                            value={maxPrice}
                            onChange={handleMinPriceChange}
                        />
                        <BtnNeon
                            text={'Clear'}
                            onClick={handleResetPrice}
                            disabled={!maxPrice}
                        />
                    </div>

                    <div>
                        <label htmlFor="rating">Minimal Rating:</label>
                        <input
                            ref={ratingRef}
                            type="number"
                            name="rating"
                            id="rating"
                            value={minRating}
                            min={1}
                            max={5}
                            onChange={handleMinRatingChange}
                        />
                        <BtnNeon
                            text={'Clear'}
                            onClick={handleResetRating}
                            disabled={!minRating}
                        />
                    </div>

                </div>
            </div>
            {(maxPrice || minRating) &&
                <div className='results-are-filtered-div'>
                    <p>RESULTS FILTERED BY
                        {minRating ? ' MIN RATING OF ' + minRating : ''}
                        {(minRating && maxPrice) ? ' &' : ''}
                        {maxPrice ? ' MAX PRICE OF $' + maxPrice : ''}</p>
                    <button className='btn-remove-filter' onClick={handleResetAll}>Reset</button>
                </div>}
        </>
    )
}

export default Filter