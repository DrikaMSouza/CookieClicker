using System.ComponentModel;
using System.Runtime.CompilerServices;

public class CookieClickerViewModel : INotifyPropertyChanged
{
    private int _HouseCandyCount;
    public int HouseCandyCount
    {
        get => _HouseCandyCount;
        set
        {
            if (_HouseCandyCount != value)
            {
                _HouseCandyCount = value;
                OnPropertyChanged();
            }
        }
    }

    // HouseCandy Buyer
    public bool CanBuyHouseCandy => CookieCount >= 50;
    public void BuyHouseCandy()
    {
        if (CookieCount >= 50)
        {
            CookieCount -= 50;
            HouseCandyCount++;
            OnPropertyChanged(nameof(CanBuyHouseCandy));
            StartHouseCandyTimer();
        }
    }

    private System.Timers.Timer _HouseCandyTimer;

    private void StartHouseCandyTimer()
    {
        if (_HouseCandyTimer == null)
        {
            _HouseCandyTimer = new System.Timers.Timer(15000); 
            _HouseCandyTimer.Elapsed += (s, e) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    CookieCount += HouseCandyCount;
                });
            };
            _HouseCandyTimer.Start();
        }
    }

    private int _GrandMotherCount;
    public int GrandMotherCount
    {
        get => _GrandMotherCount;
        set
        {
            if (_GrandMotherCount != value)
            {
                _GrandMotherCount = value;
                OnPropertyChanged();
            }
        }
    }

    // GrandMother Buyer
    public bool CanBuyGrandMother => CookieCount >= 10;

    public void BuyGrandMother()
    {
        if (CookieCount >= 10)
        {
            CookieCount -= 10;
            GrandMotherCount++;
            OnPropertyChanged(nameof(CanBuyGrandMother));
            StartGrandMotherTimer();
        }
    }

    private System.Timers.Timer _GrandMotherTimer;

    private void StartGrandMotherTimer()
    {
        if (_GrandMotherTimer == null)
        {
            _GrandMotherTimer = new System.Timers.Timer(5000);
            _GrandMotherTimer.Elapsed += (s, e) =>
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    CookieCount += GrandMotherCount;
                });
            };
            _GrandMotherTimer.Start();
        }
    }

    private int _cookieCount;
    public int CookieCount
    {
        get => _cookieCount;
        set
        {
            if (_cookieCount != value)
            {
                _cookieCount = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CanBuyGrandMother));
                OnPropertyChanged(nameof(CanBuyHouseCandy));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void IncrementCookie()
    {
        CookieCount++;
    }
}
