import React, { useState } from 'react';
import ExchangeRateList from './ExchangeRateList';
import ExchangeRateDetail from './ExchangeRateDetail';

function App() {
  const [selectedExchangeRate, setSelectedExchangeRate] = useState(null);

  const handleCloseDetail = () => setSelectedExchangeRate(null);

  return (
    <div className="container">
      <ExchangeRateList onSelectExchangeRate={setSelectedExchangeRate} />
      {selectedExchangeRate && <ExchangeRateDetail exchangeRate={selectedExchangeRate} onClose={handleCloseDetail} />}
    </div>
  );
}


export default App;
