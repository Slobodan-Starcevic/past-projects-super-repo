import { ResponsiveBar } from '@nivo/bar'


export default function BuildingBarChart({ data }){

    const maxValue = Math.max(...data.map(item => item.incidents)) * 1.2;


    return(
        <ResponsiveBar
            data={data}
            keys={['incidents']}
            indexBy="date"
            margin={{ top: 50, right: 60, bottom: 50, left: 60 }}
            padding={0.3}
            valueScale={{ type: 'linear', max: maxValue }}
            layout="horizontal"
            indexScale={{ type: 'band', round: true }}
            colors="#9fcae1"
            borderRadius={3}
            defs={[
                {
                    id: 'dots',
                    type: 'patternDots',
                    background: 'inherit',
                    color: '#38bcb2',
                    size: 4,
                    padding: 1,
                    stagger: true
                },
                {
                    id: 'lines',
                    type: 'patternLines',
                    background: 'inherit',
                    color: '#eed312',
                    rotation: -45,
                    lineWidth: 6,
                    spacing: 10
                }
            ]}
            borderColor={{
                from: 'color',
                modifiers: [['darker', 1.6]]
            }}
            axisTop={null}
            axisRight={null}
            axisBottom={{
                tickSize: 5,
                tickPadding: 5,
                tickRotation: 60,
                truncateTickAt: 0
            }}
            axisLeft={{
                tickSize: 5,
                tickPadding: 5,
                tickRotation: 0,
                legend: 'incidents',
                legendPosition: 'middle',
                legendOffset: -40,
                truncateTickAt: 0,
            }}
            labelSkipWidth={12}
            labelSkipHeight={12}
            labelTextColor={'#000'}
            role="application"
            ariaLabel="Nivo bar chart demo"
            barAriaLabel={e => `${e.id}: ${e.formattedValue} in country: ${e.indexValue}`}
        />
    )
}
