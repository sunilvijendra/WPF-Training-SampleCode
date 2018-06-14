
// DemoInteropDlg.h : header file
//

#pragma once

ref class CEnetCapacityWpfMgr
{
public:
	//static RAEnetCapacity::UCEnetCapacity^ m_Control				= nullptr; // Handle to WPF control
	static WPFClock::Clock^ m_Control				= nullptr; // Handle to WPF control
	static System::Windows::Interop::HwndSource^ m_hwndSource		= nullptr;

};

// CDemoInteropDlg dialog
class CDemoInteropDlg : public CDialogEx
{
// Construction
public:
	CDemoInteropDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_DEMOINTEROP_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	afx_msg void OnBnClickedButton1();
	CStatic m_stcHost;
};
