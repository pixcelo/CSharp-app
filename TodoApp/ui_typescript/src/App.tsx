import React, { useEffect, useState } from 'react';
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend } from 'recharts';

// const data = [
//   { name: 'Page A', uv: 4000, pv: 2400, amt: 2400 },
//   { name: 'Page B', uv: 3000, pv: 1398, amt: 2210 },
//   { name: 'Page C', uv: 2000, pv: 9800, amt: 2290 },
//   { name: 'Page D', uv: 2780, pv: 3908, amt: 2000 },
//   { name: 'Page E', uv: 1890, pv: 4800, amt: 2181 },
//   { name: 'Page F', uv: 2390, pv: 3800, amt: 2500 },
//   { name: 'Page G', uv: 3490, pv: 4300, amt: 2100 },
// ];

// APIレスポンスの型を定義
interface ApiResponse {
  Name: string;
  Uv: number;
  Pv: number;
  Amt: number;
}

// チャートで使用するデータの型を定義
interface ChartData {
  name: string;
  uv: number;
  pv: number;
  amt: number;
}

function App() {
  const [data, setData] = useState<ChartData[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('http://localhost:5297/api/MockApi/GetChartData');
        if (!response.ok) {
          throw new Error('Data fetch failed');
          
        }
        const result = await response.json();
        const formattedData: ChartData[] = result.map((item: ApiResponse) => ({
          name: item.Name,
          uv: item.Uv,
          pv: item.Pv,
          amt: item.Amt
        }));
        
        setData(formattedData); // APIから取得したデータをセット
      } catch (error) {
        console.error("Error fetching data: ", error);
      }
    };

    fetchData();
  }, []); // 空の依存配列を渡して、コンポーネントのマウント時にのみ実行されるようにする

  return (
    <div className="App">
      <LineChart width={500} height={300} data={data}
        margin={{ top: 5, right: 30, left: 20, bottom: 5 }}>
        <CartesianGrid strokeDasharray="3 3" />
        <XAxis dataKey="name" />
        <YAxis />
        <Tooltip />
        <Legend />
        <Line type="monotone" dataKey="pv" stroke="#8884d8" activeDot={{ r: 8 }}/>
        <Line type="monotone" dataKey="uv" stroke="#82ca9d" />
      </LineChart>
    </div>
  );
}

export default App;
