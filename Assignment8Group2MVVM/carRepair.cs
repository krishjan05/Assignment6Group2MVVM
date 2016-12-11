using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8Group2MVVM
{
    class carRepair: INotifyPropertyChanged
    {
        #region CONSTANTS & VARIABLES
        const double COST_OIL_CHANGE = 26.00;
        const double COST_LUBE_JOB = 18.00;
        const double COST_RADIATOR_FLUSH = 30.00;
        const double COST_TRANSMISSION_FLUSH = 80.00;
        const double COST_INSPECTION = 15.00;
        const double COST_MUFFLER_REPLACEMENT = 100.00;
        const double COST_TIRE_ROTATION = 20.00;
        const double COST_LABOR = 20.00;
        const double TAX_MULTIPLIER = 0.06;
        const double costPart = 0.00;
        double costParts;
        double costLabour;
        #endregion

        #region PROPERTIES
        public bool isOilChangedChecked
        {
            get { return _isOilChangedChecked; }
            set { _isOilChangedChecked = value; OnPropertyChanged(); }
        }
        private bool _isOilChangedChecked;
        public bool isLubeJobChecked
        {
            get { return _isLubeJobChecked; }
            set { _isLubeJobChecked = value; OnPropertyChanged(); }
        }
        private bool _isLubeJobChecked;
        public bool isRadiatorFlashChecked
        {
            get { return _isRadiatorFlashChecked; }
            set { _isRadiatorFlashChecked = value; OnPropertyChanged(); }
        }
        private bool _isRadiatorFlashChecked;
        public bool isTransmissionFlashChecked
        {
            get { return _isTransmissionFlashChecked; }
            set { _isTransmissionFlashChecked = value; OnPropertyChanged(); }
        }
        private bool _isTransmissionFlashChecked;
        public bool isInspectionChecked
        {
            get { return _isInspectionChecked; }
            set { _isInspectionChecked = value; OnPropertyChanged(); }
        }
        private bool _isInspectionChecked;
        public bool isMufflerRotationChecked
        {
            get { return _isMufflerRotationChecked; }
            set { _isMufflerRotationChecked = value; OnPropertyChanged(); }
        }
        private bool _isMufflerRotationChecked;
        public bool isTireRotationChecked
        {
            get { return _isTireRotationChecked; }
            set { _isTireRotationChecked = value; OnPropertyChanged(); }
        }
        private bool _isTireRotationChecked;
        public double labourDuration
        {
            get { return _labourDuration; }
            set { _labourDuration = value; OnPropertyChanged(); }
        }
        private double _labourDuration;
        public double partCost
        {
            get { return _partCost; }
            set { _partCost = value; OnPropertyChanged(); }
        }
        private double _partCost;
        public double totalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; OnPropertyChanged(); }
        }
        private double _totalCost;
        #endregion

        public double OilLubeCharges()
        {
            if (_isOilChangedChecked)
            {
                if (_isLubeJobChecked)
                    return COST_OIL_CHANGE + COST_LUBE_JOB;
                else
                    return COST_OIL_CHANGE;
            }else
            {
                if (_isLubeJobChecked)
                    return COST_LUBE_JOB;
                else
                    return 0.00;
            }  
        }
        public double FlushCharges()
        {
            if (_isRadiatorFlashChecked)
            {
                if (_isTransmissionFlashChecked)
                    return COST_RADIATOR_FLUSH + COST_TRANSMISSION_FLUSH;
                else
                    return COST_RADIATOR_FLUSH;
            }else
            {
                if (_isTransmissionFlashChecked)
                    return COST_TRANSMISSION_FLUSH;
                else
                    return 0.00;
            }
        }
        public double MiscCharges()
        {
            if (_isInspectionChecked)
            {
                if (_isMufflerRotationChecked)
                {
                    if (_isTireRotationChecked)
                        return COST_INSPECTION + COST_MUFFLER_REPLACEMENT + COST_TIRE_ROTATION;
                    else
                        return COST_INSPECTION + COST_MUFFLER_REPLACEMENT;
                }else
                {
                    if (_isTireRotationChecked)
                        return COST_INSPECTION + COST_TIRE_ROTATION;
                    else
                        return COST_INSPECTION;
                }
            }else
            {
                if (_isMufflerRotationChecked)
                {
                    if (_isTireRotationChecked)
                        return COST_MUFFLER_REPLACEMENT + COST_TIRE_ROTATION;
                    else
                        return COST_MUFFLER_REPLACEMENT;
                }
                else
                {
                    if (_isTireRotationChecked)
                        return COST_TIRE_ROTATION;
                    else
                        return 0.00;
                }

            }
        }
        public double OtherCharges()
        {
            double othercharges = COST_LABOR * _labourDuration;
            return othercharges;
        }
        public double TaxCharges()
        {
            double taxCharges = 0.00;
            if (_partCost != 0.00)
            {
                taxCharges = TAX_MULTIPLIER * _partCost;
                return taxCharges + _partCost;
            }
            else
                return taxCharges;
        }
        public double TotalCharges()
        {
            _totalCost = OilLubeCharges() + FlushCharges() + MiscCharges() + OtherCharges() + TaxCharges();
            totalCost = _totalCost;
            return totalCost;
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string caller = "")
        {
            // make sure only to call this if the value actually changes

            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }
        #endregion

    }
}
